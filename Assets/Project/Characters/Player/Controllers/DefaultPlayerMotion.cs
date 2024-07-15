using System.Collections;
using UnityEngine;
using Assets.Scenes.Global;

namespace Assets.Scenes.Characters.Player.Controllers
{
    public class DefaultPlayerMotion : MotionBase, IMotion
    {
        private bool _isJumping = false;
        
        private readonly float _crouchedSpeed;

        private readonly float _jumpForce;

        public DefaultPlayerMotion(MotionBase baseModel, float crouchedSpeed, float jumpForce)
        {
            SetStateFromOtherObject(baseModel);

            _crouchedSpeed = crouchedSpeed;
            _jumpForce = jumpForce;
        }

        public void Move(float verticalMovement, float horizontalMovement)
        {
            bool isCrouched = Input.GetKey(Navigation.crouchWalkButton);

            Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);
            Vector3 newPosition = _rigidbody.position + movement * Time.fixedDeltaTime * (isCrouched ? _crouchedSpeed : _speed);
            Vector3 clampedPosition = _transform.TransformDirection(Vector3.ClampMagnitude(newPosition - _rigidbody.position, Time.fixedDeltaTime * _speed));
            //Vector3 clampedPosition = Vector3.ClampMagnitude(newPosition - _rigidbody.position, Time.fixedDeltaTime * _speed);

            if (movement.magnitude != 0)
            {
                _rigidbody.MoveRotation(Quaternion.Lerp(_transform.rotation, Quaternion
                .LookRotation(Vector3.ClampMagnitude(clampedPosition * Time.fixedDeltaTime, 1)), _rotationSpeed));
            }

            _rigidbody.MovePosition(_rigidbody.position + clampedPosition);

            if (_isJumping == false && Input.GetKey(Navigation.jumpButton))
            {
                _isJumping = true;
                _rigidbody.AddForce(new Vector3(0, 1, 0) * _jumpForce);

                _monoBehaviour.StartCoroutine(ResetJumping());
            }

            if (_isJumping)
            {
                Jump();
            }
            else
            {
                if (clampedPosition.magnitude != 0)
                {
                    if (isCrouched)
                    {
                        CrouchWalking();
                    }
                    else
                    {
                        Runing();
                    }
                }
                else
                {
                    if (isCrouched)
                    {
                        CrouchStanding();
                    }
                    else
                    {
                        Standing();
                    }
                }
            }
        }

        private void Standing()
        {
            _animatorState.SetAnimatorInRange(0.08f, 1.96f, GlobalVariables.animatorBorder);
        }

        private void Runing()
        {
            _animatorState.SetAnimatorInRange(-8.57f, -5.46f, GlobalVariables.animatorBorder);
        }

        private void Jump()
        {
            _animatorState.SetAnimatorInRange(7.31f, 10.26f, GlobalVariables.animatorBorder);
        }

        private void CrouchWalking()
        {
            _animatorState.SetAnimatorInRange(-8.37f, 10.26f, GlobalVariables.animatorBorder);
        }

        private void CrouchStanding()
        {
            _animatorState.SetAnimatorInRange(-3.92f, 5.81f, GlobalVariables.animatorBorder);
        }

        private IEnumerator ResetJumping()
        {
            yield return new WaitForSeconds(GlobalVariables.jumpingTimeInSeconds);
            _isJumping = false;
        }
    }
}
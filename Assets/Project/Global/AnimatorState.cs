using UnityEngine;

namespace Assets.Scenes.Global
{
    public class AnimatorState
    {
        private float _animatorPositionX = 0.0f;

        private float _animatorPositionY = 0.0f;

        private float _animatorAcceleration = 0.0f;

        private Animator _animator;

        public AnimatorState(float animatorAcceleration, Animator animator)
        {
            _animatorAcceleration = animatorAcceleration;
            _animator = animator;
        }

        public void SetAnimatorInRange(float positionX, float positionY, float deviation)
        {
            float value = Time.fixedDeltaTime * _animatorAcceleration;

            if (Utils.IsValueInRange(positionX - deviation, positionX + deviation, _animatorPositionX) == false)
            {
                _animatorPositionX += (_animatorPositionX < positionX) ? value : -value;
            }
            else
            {
                _animatorPositionX = positionX;
            }

            if (Utils.IsValueInRange(positionY - deviation, positionY + deviation, _animatorPositionY) == false)
            {
                _animatorPositionY += (_animatorPositionY < positionY) ? value : -value;
            }
            else
            {
                _animatorPositionY = positionY;
            }

            _animator.SetFloat("Position X", _animatorPositionX);
            _animator.SetFloat("Position Y", _animatorPositionY);
        }
    }
}
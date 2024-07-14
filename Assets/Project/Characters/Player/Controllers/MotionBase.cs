using Assets.Scenes.Global;
using UnityEngine;

namespace Assets.Scenes.Characters.Player.Controllers
{
    public class MotionBase
    {
        protected AnimatorState _animatorState;

        protected MonoBehaviour _monoBehaviour;

        protected Rigidbody _rigidbody;

        protected float _rotationalAcceleration;

        protected float _rotationSpeed;

        protected float _speed;

        protected Transform _transform;

        protected MotionBase() { }

        /// <summary>
        /// This class can be created only for
        /// setting params for a child class.
        /// </summary>
        /// <param name="animatorState">Using for smoothly changing animation</param>
        /// <param name="monoBehaviour">Using for start courutine</param>
        /// <param name="rigidbody">Using for move the object</param>
        /// <param name="rotationalAcceleration">Speed of changing the animations</param>
        /// <param name="rotationSpeed">Rotation speed</param>
        /// <param name="speed">Character speed</param>
        /// <param name="transform">Character position</param>
        public MotionBase
        (
            AnimatorState animatorState,
            MonoBehaviour monoBehaviour,
            Rigidbody rigidbody,
            float rotationalAcceleration,
            float rotationSpeed,
            float speed,
            Transform transform
        )
        {
            _animatorState = animatorState;
            _monoBehaviour = monoBehaviour;
            _rigidbody = rigidbody;
            _rotationalAcceleration = rotationalAcceleration;
            _rotationSpeed = rotationSpeed;
            _speed = speed;
            _transform = transform;
        }

        public void SetStateFromOtherObject(MotionBase other)
        {
            _animatorState = other._animatorState;
            _monoBehaviour = other._monoBehaviour;
            _rigidbody = other._rigidbody;
            _rotationSpeed = other._rotationSpeed;
            _speed = other._speed;
            _transform = other._transform;
        }
    }
}
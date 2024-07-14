using Assets.Scenes.Characters.Player.Controllers;
using Assets.Scenes.Global;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 20)] public float rotationSpeed = 20.0f;

    [Range(0, 20)] public float speed = 8.0f;

    [Range(0, 20)] public float crounchedSpeed = 4.0f;

    [Range(0, 10000)] public float jumpForce = 10.0f;

    [Range(0, 5)] public float rotationalAcceleration = 2.0f;

    [Range(0, 60)] public float animatorAcceleration = 40.0f;

    public Camera mainCamera = null!;

    private Rigidbody _rigidbody;

    private DefaultPlayerMotion _defaultPlayerMotion;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        MotionBase motionBase = new MotionBase
        (
            new AnimatorState(animatorAcceleration, GetComponent<Animator>()),
            this,
            _rigidbody,
            rotationalAcceleration,
            rotationSpeed,
            speed,
            transform
        );

        _defaultPlayerMotion = new DefaultPlayerMotion(motionBase, crounchedSpeed, jumpForce);
    }

    private void FixedUpdate()
    {
        float horizontalMovement = GetHorizontalMovement();
        float verticalMovement = GetVerticalMovement();

        _defaultPlayerMotion.Move(verticalMovement, horizontalMovement);
    }

    public float GetHorizontalMovement()
    {
        if (Input.GetKey(Navigation.moveLeftButton))
            return -1;
        else if (Input.GetKey(Navigation.moveRightButton))
            return 1;
        else
            return 0;
    }

    public float GetVerticalMovement()
    {
        if (Input.GetKey(Navigation.moveBackwardButton))
            return -1;
        else if (Input.GetKey(Navigation.moveFrowardButton))
            return 1;
        else
            return 0;
    }
}
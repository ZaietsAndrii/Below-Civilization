using System;
using UnityEngine;

public class StateMachineData
{
    public float XVelocity;
    public float YVelocity;
    public float ZVelocity;

    public float XRotationVelocity;
    public float YRotationVelocity;
    public float ZRotationVelocity;
    public float CameraTargetPitch;


    private float _speed;
    private float _xInput;
    private float _yInput;

    private float _rotationSpeed;
    private float _xRotationInput;
    private float _yRotationInput;
    private float _bottomClamp;
    private float _topClamp;





    public float YInput
    {
        get => _yInput;
        set
        {
            if (value < -1 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(value));

            _yInput = value;
        }
    }

    public float XInput
    {
        get => _xInput;
        set
        {
            if (value < -1 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(value));

            _xInput = value;
        }
    }

    public float Speed
    {
        get => _speed;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _speed = value;
        }
    }


    public float RotationSpeed
    {
        get => _rotationSpeed;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _rotationSpeed = value;
        }
    }

    public float XRotationInput
    {
        get { return _xRotationInput; }
        set { _xRotationInput = value; }
    }

    public float YRotationInput
    {
        get { return _yRotationInput; }
        set { _yRotationInput = value; }
    }

    public float BottomClamp
    {
        get => _bottomClamp;
        set { _bottomClamp = value; }
    }

    public float TopClamp
    {
        get => _topClamp;
        set { _topClamp = value; }
    }

}

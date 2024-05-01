using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;

    private readonly Character _character;

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _character = character;
    }

    protected PlayerInput Input => _character.Input;
    protected CharacterController CharacterController => _character.Controller;
    protected CharacterView View => _character.View;
    protected Transform CameraTarget => _character.CameraTarget;
    protected Transform RaycastPoint => _character.RaycastPoint;


    public virtual void Enter()
    {
        Debug.Log(GetType());

        View.StartMovement();

        Data.RotationSpeed = 6f;
        Data.BottomClamp = -89f;
        Data.TopClamp = 89f;

        AddInputActionCallbacks();
    }

    public virtual void Exit()
    {
        View.StopMovement();

        RemoveInputActionCallbacks();
    }

    public virtual void HandleInput()
    {
        Data.XInput = ReadHorizontalInput();
        Data.YInput = ReadVerticalInput();
        Vector3 inputDirection = CharacterController.transform.right * Data.XInput + CharacterController.transform.forward * Data.YInput;
        Data.XVelocity = inputDirection.x * Data.Speed;
        Data.ZVelocity = inputDirection.z * Data.Speed;

        Data.XRotationInput = ReadXMousePosition();
        Data.YRotationInput = ReadYMousePosition();
        //Debug.Log(Data.XRotationVelocity);
        Data.XRotationVelocity = Data.YRotationInput * Data.RotationSpeed;
        Data.YRotationVelocity = Data.XRotationInput * Data.RotationSpeed;


    }

    public virtual void Update()
    {
        Vector3 velocity = GetConvertedVelocity();
        Vector3 velocity2 = velocity;

        CharacterController.Move(velocity * Time.deltaTime);


        Vector3 characterRotationVelocity = GetConvertedVerticalRotationVelocity() * Time.deltaTime;
        Data.CameraTargetPitch += -Data.XRotationVelocity * Time.deltaTime;
        Data.CameraTargetPitch = Math.Clamp(Data.CameraTargetPitch, Data.BottomClamp, Data.TopClamp);
        CharacterController.transform.Rotate(characterRotationVelocity);
        CameraTarget.localRotation = Quaternion.Euler(Data.CameraTargetPitch, 0, 0);
        RaycastPoint.localRotation = Quaternion.Euler(Data.CameraTargetPitch, 0, 0);
    }

    protected virtual void AddInputActionCallbacks() { }
    protected virtual void RemoveInputActionCallbacks() { }

    protected bool IsHorizontalandVerticalInputZero() => Data.XInput == 0f && Data.YInput == 0f;

    private float ReadHorizontalInput() => Input.Player.Move.ReadValue<Vector2>().x;

    private float ReadVerticalInput() => Input.Player.Move.ReadValue<Vector2>().y;

    private float ReadXMousePosition() => Input.Player.Look.ReadValue<Vector2>().x;

    private float ReadYMousePosition() => Input.Player.Look.ReadValue<Vector2>().y;

    private Vector3 GetConvertedVelocity() => new Vector3(Data.XVelocity, Data.YVelocity, Data.ZVelocity);

    private Vector3 GetConvertedVerticalRotationVelocity() => new Vector3(0, Data.YRotationVelocity, 0);


}

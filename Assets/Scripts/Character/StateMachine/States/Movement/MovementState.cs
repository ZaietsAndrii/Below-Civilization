using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementState : PlayerState
{
    private readonly Character _character;

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _character = character;
    }

    protected Transform CameraTarget => _character.CameraTarget;
    protected Transform RaycastPoint => _character.RaycastPoint;


    public override void Enter()
    {
        base.Enter();

        View.StartMovement();

        Data.RotationSpeed = 6f;
        Data.BottomClamp = -89f;
        Data.TopClamp = 89f;
    }

    public override void Exit()
    {
        base.Exit();
        View.StopMovement();

    }

    public override void HandleInput()
    {
        base.HandleInput();

        Vector3 inputDirection = CharacterController.transform.right * Data.XInput + CharacterController.transform.forward * Data.YInput;
        Data.XVelocity = inputDirection.x * Data.Speed;
        Data.ZVelocity = inputDirection.z * Data.Speed;

        Data.XRotationVelocity = Data.YRotationInput * Data.RotationSpeed;
        Data.YRotationVelocity = Data.XRotationInput * Data.RotationSpeed;
    }

    public override void Update()
    {
        base.Update();

        Vector3 velocity = GetConvertedVelocity();

        CharacterController.Move(velocity * Time.deltaTime);


        Vector3 characterRotationVelocity = GetConvertedVerticalRotationVelocity() * Time.deltaTime;
        Data.CameraTargetPitch += -Data.XRotationVelocity * Time.deltaTime;
        Data.CameraTargetPitch = Math.Clamp(Data.CameraTargetPitch, Data.BottomClamp, Data.TopClamp);
        CharacterController.transform.Rotate(characterRotationVelocity);
        CameraTarget.localRotation = Quaternion.Euler(Data.CameraTargetPitch, 0, 0);
        RaycastPoint.localRotation = Quaternion.Euler(Data.CameraTargetPitch, 0, 0);
    }
    private Vector3 GetConvertedVelocity() => new Vector3(Data.XVelocity, Data.YVelocity, Data.ZVelocity);
    private Vector3 GetConvertedVerticalRotationVelocity() => new Vector3(0, Data.YRotationVelocity, 0);


}

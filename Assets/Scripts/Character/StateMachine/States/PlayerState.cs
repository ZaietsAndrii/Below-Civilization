using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class PlayerState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;

    private readonly Character _character;

    public PlayerState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _character = character;
    }

    protected PlayerInput Input => _character.Input;
    protected CharacterController CharacterController => _character.Controller;
    protected CharacterView View => _character.View;

    public virtual void Enter()
    {
        Debug.Log(GetType());

        AddInputActionCallbacks();
    }

    public virtual void Exit()
    {
        RemoveInputActionCallbacks();
    }

    public virtual void HandleInput()
    {
        Data.XInput = ReadHorizontalInput();
        Data.YInput = ReadVerticalInput();

        Data.XRotationInput = ReadXMousePosition();
        Data.YRotationInput = ReadYMousePosition();
    }

    public virtual void Update()
    {
    }

    protected virtual void AddInputActionCallbacks() { }
    protected virtual void RemoveInputActionCallbacks() { }

    private float ReadHorizontalInput() => Input.Player.Move.ReadValue<Vector2>().x;

    private float ReadVerticalInput() => Input.Player.Move.ReadValue<Vector2>().y;

    private float ReadXMousePosition() => Input.Player.Look.ReadValue<Vector2>().x;

    private float ReadYMousePosition() => Input.Player.Look.ReadValue<Vector2>().y;
    protected bool IsHorizontalandVerticalInputZero() => Data.XInput == 0f && Data.YInput == 0f;

}

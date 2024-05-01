using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AirbornState : MovementState
{
    private readonly AirbornStateConfig _config;
    private readonly Gravity _gravity;

    public AirbornState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.AirbornStateConfig;
        _gravity = new Gravity();
    }

    public override void Enter()
    {
        base.Enter();

        View.StartAirborn();

        Data.Speed = _config.Speed;

    }

    public override void Exit()
    {
        base.Exit();

        View.StopAirborn();

        _gravity.ResetGravity();
    }

    public override void Update()
    {
        base.Update();

        Data.YVelocity += GetGeavityMaltiplayer();
    }

    protected virtual float GetGeavityMaltiplayer() => _gravity.GetCalculatedGravity() * Time.deltaTime;
}

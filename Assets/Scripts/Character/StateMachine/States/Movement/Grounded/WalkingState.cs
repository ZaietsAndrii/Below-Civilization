using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : GroundedState
{
    private readonly WalkingStateConfig _config;

    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.GroundedStateConfig.WalkingStateConfig;
    }

    public override void Enter()
    {
        base.Enter();

        View.StartWalking();

        Data.Speed = _config.Speed;
    }

    public override void Exit()
    {
        base.Exit();

        View.StopWalking();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalandVerticalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
    }
}

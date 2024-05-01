using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : AirbornState
{
    private readonly GroundChecker _groundChecker;
    public FallingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _groundChecker = character.GroundChecker;
    }

    public override void Enter()
    {
        base.Enter();

        View.StartFalling();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopFalling();
    }

    public override void Update()
    {
        base.Update();

        if(_groundChecker.IsGrounded)
        {
            Data.YVelocity = 0;

            if (IsHorizontalandVerticalInputZero())
                StateSwitcher.SwitchState<IdlingState>();
            else
                StateSwitcher.SwitchState<WalkingState>();
        }
    }
}

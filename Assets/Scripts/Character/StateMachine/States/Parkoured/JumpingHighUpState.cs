using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingHighUpState : ParkouredState
{
    private AnimationMatchingParameters _config;
    private ObstacleChecker _obstacleChecker;
    public JumpingHighUpState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.ParkouredStateConfig.JumpingHighUpStateConfig.AnimationMatchingConfigs;
        _obstacleChecker = character.ObstacleChecker;
    }

    public override void Enter()
    {
        base.Enter();

        View.StartJumpingHighUp();

        _character.StartCoroutine(PerformAction(_obstacleChecker, _config));
    }

    public override void Exit()
    {
        base.Exit();

        View.StopJumpingHighUp();
    }
}

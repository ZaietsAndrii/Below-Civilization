using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingUpState : ParkouredState
{
    private AnimationMatchingParameters _config;
    private ObstacleChecker _obstacleChecker;
    public ClimbingUpState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.ParkouredStateConfig.ClimbingUpStateConfig.AnimationMatchingConfigs;
        _obstacleChecker = character.ObstacleChecker;
    }

    public override void Enter()
    {
        base.Enter();

        View.StartClimbingUp();

        _character.StartCoroutine(PerformAction(_obstacleChecker, _config));
    }

    public override void Exit()
    {
        base.Exit();

        View.StopClimbingUp();
    }
}

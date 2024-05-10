using System.Collections;
using UnityEngine;

public class JumpingUpState : ParkouredState
{
    private AnimationMatchingParameters _config;
    private ObstacleChecker _obstacleChecker;
    public JumpingUpState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.ParkouredStateConfig.JumpingUpStateConfig.AnimationMatchingConfigs;
        _obstacleChecker = character.ObstacleChecker;
    }

    public override void Enter()
    {
        base.Enter();

        View.StartJumpingUp();

        _character.StartCoroutine(PerformAction(_obstacleChecker, _config));     
    }

    public override void Exit()
    {
        base.Exit();

        View.StopJumpingUp();
    }
}

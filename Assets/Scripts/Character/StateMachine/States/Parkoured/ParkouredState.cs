using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class ParkouredState : PlayerState
{
    protected readonly Character _character;

    public ParkouredState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _character = character;
    }

    protected Animator Animator => _character.View.GetComponent<Animator>();

    public override void Enter()
    {
        base.Enter();

        View.StartParkoured();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopParkoured();
    }

    protected void CompareTarget(TargetParameters _compareTargetParameter)
    {
        Animator.MatchTarget(_compareTargetParameter.position, _character.transform.rotation, _compareTargetParameter.bodyPart,
            new MatchTargetWeightMask(_compareTargetParameter.positionWeight, 0), _compareTargetParameter.startTime, _compareTargetParameter.endTime);
    }

    protected IEnumerator PerformAction(ObstacleChecker obstacleChecker, AnimationMatchingParameters config)
    {
        CharacterController.enabled = false;
        ObstacleInfo obstacleInfo = obstacleChecker.Check();
        Quaternion requiredRotation = Quaternion.LookRotation(-obstacleInfo.hitInfo.normal);
        TargetParameters targetParameters = GetTargetParameters(obstacleInfo, config);

        yield return null;
        float timerCounter = 0f;

        while (timerCounter <= Animator.GetCurrentAnimatorStateInfo(0).length)
        {
            timerCounter += Time.deltaTime;

            if (config.LookAtObstacle == true)
                CharacterController.transform.rotation = Quaternion.RotateTowards(CharacterController.transform.rotation, requiredRotation, Time.deltaTime * config.RotationSpeed);
            if (config.AllowTargetMatching == true)
                CompareTarget(targetParameters);
            if (Animator.IsInTransition(0) && timerCounter > 0.5f)
            {
                break;
            }
            yield return null;
        }

        yield return new WaitForSeconds(config.Delay);
        CharacterController.enabled = true;


        if (IsHorizontalandVerticalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
        else
            StateSwitcher.SwitchState<WalkingState>();
    }

    private TargetParameters GetTargetParameters(ObstacleInfo obstacleInfo, AnimationMatchingParameters animationMatchingParameters)
    {
        return new TargetParameters
        {
            position = obstacleInfo.hitHeightInfo.point,
            bodyPart = animationMatchingParameters.CompareBodyPart,
            positionWeight = animationMatchingParameters.ComparePositionWeight,
            startTime = animationMatchingParameters.CompareStartTime,
            endTime = animationMatchingParameters.CompareEndTime
        };
    }
}

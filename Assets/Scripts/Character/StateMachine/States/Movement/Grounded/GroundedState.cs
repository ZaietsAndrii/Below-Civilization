using UnityEngine.InputSystem;
using UnityEngine;

public abstract class GroundedState : MovementState
{
    private readonly GroundChecker _groundChecker;
    private readonly ObstacleChecker _obstacleChecker;

    private readonly JumpingUpStateConfig _jumpingUpConfig;
    private readonly JumpingHighUpStateConfig _jumpingHighUpConfig;
    private readonly ClimbingUpStateConfig _climbingUpStateConfig;


    public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _groundChecker = character.GroundChecker;
        _obstacleChecker = character.ObstacleChecker;

        _jumpingUpConfig = character.Config.ParkouredStateConfig.JumpingUpStateConfig;
        _jumpingHighUpConfig = character.Config.ParkouredStateConfig.JumpingHighUpStateConfig;
        _climbingUpStateConfig = character.Config.ParkouredStateConfig.ClimbingUpStateConfig;
    }

    public override void Enter()
    {
        base.Enter();

        View.StartGrouded();

    }

    public override void Exit()
    {
        base.Exit();

        View.StopGrounded();
    }

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsGrounded == false)
            StateSwitcher.SwitchState<FallingState>();


    }

    protected override void AddInputActionCallbacks()
    {
        base.AddInputActionCallbacks();

        Input.Player.Jump.started += OnJumpKeyPressed;
    }

    protected override void RemoveInputActionCallbacks()
    {
        base.RemoveInputActionCallbacks();

        Input.Player.Jump.started -= OnJumpKeyPressed;
    }

    private void OnJumpKeyPressed(InputAction.CallbackContext context)
    {
        ObstacleInfo obstacleInfo = _obstacleChecker.Check();

        if (obstacleInfo.isFoundObstacle == true)
        {
            if (obstacleInfo.hitHeightInfo.point.y >= _jumpingUpConfig.MinimumHeigh && obstacleInfo.hitHeightInfo.point.y <= _jumpingUpConfig.MaximumHeigh)
                StateSwitcher.SwitchState<JumpingUpState>();
            if (obstacleInfo.hitHeightInfo.point.y >= _jumpingHighUpConfig.MinimumHeigh && obstacleInfo.hitHeightInfo.point.y <= _jumpingHighUpConfig.MaximumHeigh)
                StateSwitcher.SwitchState<JumpingHighUpState>();
            if (obstacleInfo.hitHeightInfo.point.y >= _climbingUpStateConfig.MinimumHeigh && obstacleInfo.hitHeightInfo.point.y <= _climbingUpStateConfig.MaximumHeigh)
                StateSwitcher.SwitchState<ClimbingUpState>();


        }
        else
        {
            StateSwitcher.SwitchState<JumpingState>();
        }
    }


}

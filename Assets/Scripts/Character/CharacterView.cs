using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
    private const string IsMovement = "IsMovement";
    private const string IsGrounded = "IsGrounded";
    private const string IsAirborn = "IsAirborn";
    private const string IsIdling = "IsIdling";
    private const string IsWalking = "IsWalking";
    private const string IsRunning = "IsRunning";
    private const string IsJumping = "IsJumping";
    private const string IsFalling = "IsFalling";

    private const string IsParkoured = "IsParkoured";
    private const string IsJumpingUp = "IsJumpingUp";
    private const string IsJumpingHighUp = "IsJumpingHighUp";
    private const string IsClimbingUp = "IsClimbingUp";




    private Animator _animator;

    public void Initialize() => _animator = GetComponent<Animator>();

    public void StartMovement() => _animator.SetBool(IsMovement, true);
    public void StopMovement() => _animator.SetBool(IsMovement, false);

    public void StartGrouded() => _animator.SetBool(IsGrounded, true);
    public void StopGrounded() => _animator.SetBool(IsGrounded, false);

    public void StartAirborn() => _animator.SetBool(IsAirborn, true);
    public void StopAirborn() => _animator.SetBool(IsAirborn, false);

    public void StartIdling() => _animator.SetBool(IsIdling, true);
    public void StopIdling() => _animator.SetBool(IsIdling, false);

    public void StartWalking() => _animator.SetBool(IsWalking, true);
    public void StopWalking() => _animator.SetBool(IsWalking, false);

    public void StartRunning() => _animator.SetBool(IsRunning, true);
    public void StopRunning() => _animator.SetBool(IsRunning, false);

    public void StartJumping() => _animator.SetBool(IsJumping, true);
    public void StopJumping() => _animator.SetBool(IsJumping, false);

    public void StartFalling() => _animator.SetBool(IsFalling, true);
    public void StopFalling() => _animator.SetBool(IsFalling, false);




    public void StartParkoured() => _animator.SetBool(IsParkoured, true);
    public void StopParkoured() => _animator.SetBool(IsParkoured, false);

    public void StartJumpingUp() => _animator.SetBool(IsJumpingUp, true);
    public void StopJumpingUp() => _animator.SetBool(IsJumpingUp, false);

    public void StartJumpingHighUp() => _animator.SetBool(IsJumpingHighUp, true);
    public void StopJumpingHighUp() => _animator.SetBool(IsJumpingHighUp, false);

    public void StartClimbingUp() => _animator.SetBool(IsClimbingUp, true);
    public void StopClimbingUp() => _animator.SetBool(IsClimbingUp, false);




}

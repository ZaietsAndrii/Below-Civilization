using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class ParkouredStateConfig
{
    [SerializeField] private JumpingUpStateConfig _jumpingUpStateConfig;
    [SerializeField] private JumpingHighUpStateConfig _jumpingHighUpStateConfig;
    [SerializeField] private ClimbingUpStateConfig _climbingUpStateConfig;

    public JumpingUpStateConfig JumpingUpStateConfig => _jumpingUpStateConfig;
    public JumpingHighUpStateConfig JumpingHighUpStateConfig => _jumpingHighUpStateConfig;
    public ClimbingUpStateConfig ClimbingUpStateConfig => _climbingUpStateConfig;
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GroundedStateConfig
{
    [SerializeField] private WalkingStateConfig _walkingStateConfig;

    public WalkingStateConfig WalkingStateConfig => _walkingStateConfig;
}

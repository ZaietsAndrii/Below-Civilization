using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class JumpingUpStateConfig
{
    [SerializeField] private float _minimumHeigh;
    [SerializeField] private float _maximumHeigh;
    [SerializeField] private AnimationMatchingParameters _animationMatchingConfigs;

    public float MinimumHeigh => _minimumHeigh;
    public float MaximumHeigh => _maximumHeigh;
    public AnimationMatchingParameters AnimationMatchingConfigs => _animationMatchingConfigs;
}

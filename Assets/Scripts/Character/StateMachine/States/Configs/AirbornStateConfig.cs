using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AirbornStateConfig
{
    [SerializeField] private JumpingStateConfig _jumpingStateConfig;

    [SerializeField, Range(0f, 15f)] private float _speed;

    public float Speed => _speed;

    public JumpingStateConfig JumpingStateConfig => _jumpingStateConfig;
}

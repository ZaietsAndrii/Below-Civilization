using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class JumpingStateConfig
{
    [SerializeField, Range(0, 10)] private float _maxHeight;

    public float StartYVelocity => 1 * _maxHeight;

}

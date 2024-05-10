using System;
using UnityEngine;

[Serializable]
public class WalkingStateConfig
{
    [SerializeField, Range(1f, 5f)] private float _speed;

    public float Speed => _speed;
}

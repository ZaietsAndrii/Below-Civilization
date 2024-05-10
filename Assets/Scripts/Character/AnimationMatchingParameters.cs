using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AnimationMatchingParameters
{
    [SerializeField] private bool _allowTargetMatching;
    [SerializeField] private bool _lookAtObstacle;
    [SerializeField] private AvatarTarget _compareBodyPart;
    [SerializeField] private float _compareStartTime;
    [SerializeField] private float _compareEndTime;
    [SerializeField] private Vector3 _comparePositionWeight;
    [SerializeField] private float _delay;
    [SerializeField] private float _rotationSpeed;

    public bool AllowTargetMatching => _allowTargetMatching;
    public bool LookAtObstacle => _lookAtObstacle;
    public AvatarTarget CompareBodyPart => _compareBodyPart;
    public float CompareStartTime => _compareStartTime;
    public float CompareEndTime => _compareEndTime;
    public Vector3 ComparePositionWeight => _comparePositionWeight;
    public float Delay => _delay;
    public float RotationSpeed => _rotationSpeed;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachinePOVController
{
    private Transform _followTarget;
    private Character _character;
    private float _rotateSpeed;

    public CinemachinePOVController(Transform followTarget, Character character, float rotateSpeed)
    {
        _followTarget = followTarget;
        _character = character;
        _rotateSpeed = rotateSpeed;
    }


}

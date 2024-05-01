using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _surface;

    [SerializeField, Range(0.01f, 1f)] private float _distanceToCheck;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        IsGrounded = Physics.Raycast(transform.position, Vector3.down, _distanceToCheck, _surface);
    }
}

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
        IsGrounded = Physics.CheckSphere(transform.position, _distanceToCheck, _surface);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(transform.position, _distanceToCheck);
    //}
}

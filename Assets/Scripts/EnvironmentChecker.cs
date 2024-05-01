using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentChecker : MonoBehaviour
{
    public Vector3 rayOffset;
    public float rayLenght;
    public LayerMask obstacleLayer;

    public ObstacleInfo CheckObsyacle()
    {
        var hitData = new ObstacleInfo();

        Vector3 rayOrigin = transform.position + rayOffset;
        hitData.hitFound = Physics.Raycast(rayOrigin, transform.forward, out hitData.hitInfo, rayLenght, obstacleLayer);

        Debug.DrawRay(rayOrigin, transform.forward * rayLenght, (hitData.hitFound) ? Color.red : Color.green);

        return hitData;
    }

    private void Update()
    {
        CheckObsyacle();
    }
}

public struct ObstacleInfo
{
    public bool hitFound;
    public RaycastHit hitInfo;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleChecker : MonoBehaviour
{
    public Vector3 rayOffset;
    public float rayLenght;
    public float heightRayLenght;
    public LayerMask obstacleLayer;
    public GameObject ExampleHei;

    public ObstacleInfo Check()
    {
        ObstacleInfo hitData = new ObstacleInfo();

        Vector3 rayOrigin = transform.position + rayOffset;
         hitData.isFoundObstacle = Physics.Raycast(rayOrigin, transform.forward, out hitData.hitInfo, rayLenght, obstacleLayer);

        Debug.DrawRay(rayOrigin, transform.forward * rayLenght, (hitData.isFoundObstacle) ? Color.red : Color.green);

        if (hitData.isFoundObstacle)
        {
            Vector3 heightOrigin = hitData.hitInfo.point + Vector3.up * heightRayLenght;
            Physics.Raycast(heightOrigin, Vector3.down, out hitData.hitHeightInfo, heightRayLenght, obstacleLayer);
            Instantiate(ExampleHei, hitData.hitHeightInfo.point, Quaternion.identity);

            Debug.DrawRay(heightOrigin, Vector3.down * heightRayLenght, Color.green);
        }

        return hitData;

        
    }
}

public struct ObstacleInfo
{
    public RaycastHit hitInfo;
    public RaycastHit hitHeightInfo;
    public bool isFoundObstacle;
}

public class TargetParameters
{
    public Vector3 position;
    public AvatarTarget bodyPart;
    public Vector3 positionWeight;
    public float startTime;
    public float endTime;
}

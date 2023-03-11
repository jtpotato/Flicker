using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    float smoothTime = 0.5f;
    Vector3 velocity = Vector3.zero;
    [SerializeField] float offsetX;
    [SerializeField] float offsetY;
    [SerializeField] float offsetZ;

    void Update()
    {
        // Get desired direction from camera to target
        Vector3 desiredDir = target.rotation * new Vector3(offsetX, offsetY, offsetZ);
        Vector3 desiredPos = target.position + desiredDir;
        Vector3 smoothedCamPos = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothTime);
        transform.position = smoothedCamPos;
        
        transform.LookAt(target);
    }
}

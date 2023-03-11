using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class CameraFollow : NetworkBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Camera playerCamera;
    float smoothTime = 0.2f;
    Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        Vector3 desiredPos = target.position - new Vector3(0f, 0f, (target.position.y + 10f) * 2f);
        Vector3 smoothedCamPos = Vector3.SmoothDamp(playerCamera.transform.position, desiredPos, ref velocity, smoothTime);
        playerCamera.transform.position = smoothedCamPos;
    }
}

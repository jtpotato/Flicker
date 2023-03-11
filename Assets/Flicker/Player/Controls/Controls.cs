using System.Collections;
using System.Collections.Generic;
using Mirror;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : NetworkBehaviour
{
    float movementX;
    float movementZ;
    float jumpValue;
    [SerializeField] float speed;
    bool lockTargetAction;
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<FlickerPlayer>().playerObjectRigidbody;
    }

    void OnLockTarget()
    {
        lockTargetAction = true;
    }



    void Update()
    {

    }
}

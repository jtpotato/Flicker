using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class DestroyCamera : NetworkBehaviour
{
    [SerializeField] GameObject cameraObject;
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(cameraObject);
        }
    }
}

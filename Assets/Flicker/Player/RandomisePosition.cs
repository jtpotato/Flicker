using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class RandomisePosition : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer) return;
        GetComponent<FlickerPlayer>().playerObjectRigidbody.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class ChangeColour : NetworkBehaviour
{
    [SerializeField] Material enemyMaterial;
    [SerializeField] Material friendMaterial;
    [SerializeField] GameObject playerModel;
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            playerModel.GetComponent<MeshRenderer>().material = enemyMaterial;
        }
        else
        {
            playerModel.GetComponent<MeshRenderer>().material = friendMaterial;
        }
    }
}

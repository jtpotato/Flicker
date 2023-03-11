using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerColour: NetworkBehaviour
{
    [SerializeField] Color enemyColour;
    [SerializeField] Color friendlyColour;
    void Start()
    {
        if (!isLocalPlayer)
        {
            GetComponent<FlickerPlayer>().PlayerColour = enemyColour;
        }
        else
        {
            GetComponent<FlickerPlayer>().PlayerColour = friendlyColour;
        }
    }
}

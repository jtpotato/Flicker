using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class FlickerPlayer : NetworkBehaviour
{
    [SerializeField] GameObject playerObject;
    Color playerColour;
    public Color PlayerColour {
        get { return playerColour; }
        set {
            playerColour = value;
            playerObject.GetComponent<SpriteRenderer>().color = playerColour;
            Debug.Log("Changed Colour");
        }
    }
    void Start()
    {
        if (!isLocalPlayer)
        {
            
        }
    }
    void Update()
    {
        
    }
}

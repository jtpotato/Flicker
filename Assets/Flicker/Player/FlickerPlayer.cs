using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class FlickerPlayer : NetworkBehaviour
{
    [SerializeField] GameObject playerObject;
    public Rigidbody2D playerBody;
    public bool gliding;
    Color playerColour;
    public Color PlayerColour {
        get { return playerColour; }
        set {
            playerColour = value;
            playerObject.GetComponent<SpriteRenderer>().color = playerColour;
        }
    }
}

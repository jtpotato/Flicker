using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class DamageCalculator : NetworkBehaviour
{
    public void DamageEvent(GameObject victim)
    {
        if (!isLocalPlayer) return;
        float velocity = GetComponent<FlickerPlayer>().playerBody.velocity.magnitude;
        int damage = (int)(5 + velocity);
        Debug.Log(damage);
    }
}

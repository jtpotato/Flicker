using System.Collections;
using System.Collections.Generic;
using Mirror;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (GetComponentInParent<FlickerPlayer>().playerBody.velocity.magnitude > col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude)
            {
                GetComponentInParent<DamageCalculator>().DamageEvent(col.gameObject);
            }
        }
    }
}

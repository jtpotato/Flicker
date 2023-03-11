using System.Collections;
using System.Collections.Generic;
using Mirror;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : NetworkBehaviour
{
    float movementX;
    float jumpValue;
    Rigidbody2D rb;
    [SerializeField] float speed;

    void Start()
    {
        rb = GetComponent<FlickerPlayer>().playerBody;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
    }
    void OnJump(InputValue jumpControlValue)
    {
        jumpValue = jumpControlValue.Get<float>();
    }

    void Update()
    {
        if (!isLocalPlayer) return;

        if (rb.velocity.x != 0)
        {
            if (GetComponent<FlickerPlayer>().gliding)
            {
                if (Mathf.Abs(rb.velocity.x) < Mathf.Abs(Mathf.Ceil(movementX) * speed))
                {
                    rb.velocity = new Vector2(Mathf.Ceil(movementX) * speed, rb.velocity.y);
                    GetComponent<FlickerPlayer>().gliding = false;
                }
                else if (rb.velocity.x > 0 && Mathf.Ceil(movementX) * speed + rb.velocity.x < rb.velocity.x)
                {
                    rb.velocity = new Vector2(Mathf.Ceil(movementX) * speed, rb.velocity.y);
                    GetComponent<FlickerPlayer>().gliding = false;
                }
                else if (rb.velocity.x < 0 && Mathf.Ceil(movementX) * speed + rb.velocity.x > rb.velocity.x)
                {
                    rb.velocity = new Vector2(Mathf.Ceil(movementX) * speed, rb.velocity.y);
                    GetComponent<FlickerPlayer>().gliding = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(Mathf.Ceil(movementX) * speed, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = new Vector2(Mathf.Ceil(movementX) * speed, rb.velocity.y);
        }


        // Jump
        if (jumpValue > 0 && rb.position.y <= 20f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpValue * 20f);
            jumpValue = 0;
        }
    }
}

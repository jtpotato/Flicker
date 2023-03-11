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
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;

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

        rb.velocity = new Vector2(Mathf.Ceil(movementX) * speed, rb.velocity.y);

        // Jump
        if (jumpValue > 0 && rb.position.y <= 20f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpValue * 20f);
            jumpValue = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttack : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponentInParent<FlickerPlayer>().playerBody;
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = rb.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && curDistance > 0.1f)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    public void Attack()
    {
        GameObject target = FindClosestEnemy();
        if (!target) return;
        
        GetComponentInParent<FlickerPlayer>().gliding = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        Vector2 dashDirection = new Vector2(target.transform.position.x, target.transform.position.y) - rb.position;
        rb.AddForce(dashDirection.normalized * 1000f);
    }
}

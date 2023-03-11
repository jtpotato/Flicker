using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class LockOntoEnemy : NetworkBehaviour
{
    GameObject currentTarget;
    Rigidbody rb;

    void Start()
    {
        if (!isLocalPlayer) return;
        rb = GetComponent<FlickerPlayer>().playerObjectRigidbody;
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

    void OnLockTarget()
    {
        if (!isLocalPlayer) return;

        GameObject closestEnemy = FindClosestEnemy();
        if (closestEnemy)
        {
            currentTarget = closestEnemy;
            rb.transform.LookAt(currentTarget.transform);
        }
    }

    void Update()
    {
        if (!isLocalPlayer) return;
        if (currentTarget)
        {
            rb.AddForce((currentTarget.transform.position - rb.position).normalized * Time.deltaTime * 1000f);
        }
    }
}
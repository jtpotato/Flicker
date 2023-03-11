using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class NormalAttack : NetworkBehaviour
{
    public enum AttackBehaviours {
        DashAttack
    }
    [SerializeField] AttackBehaviours attackBehaviour;

    void OnNormalAttack()
    {
        if (!isLocalPlayer) return;
        if (attackBehaviour == AttackBehaviours.DashAttack)
        {
            GetComponentInChildren<DashAttack>().Attack();
        }
    }
}

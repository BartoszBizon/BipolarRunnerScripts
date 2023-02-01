using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] protected CapsuleCollider2D rangeDamage;    
    [SerializeField] protected LayerMask takeMeleeDamageMask;
    
    protected bool canAttack = true;
    public bool CanAttack
    {
        get => canAttack;
        set => canAttack = value;
    }
    
}

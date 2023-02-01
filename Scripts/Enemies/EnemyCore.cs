using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    [SerializeField] 
    private EnemyHealth health;
    public EnemyHealth Health => health;

    [SerializeField] 
    private Animator animator;

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}

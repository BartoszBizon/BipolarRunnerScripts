using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] 
    private EnemyHealth health;

    [SerializeField] 
    private Rigidbody2D rigidbody;
    public EnemyHealth Health => health;

    public void AddForce(Vector2 force)
    {
        rigidbody.AddForce(force,ForceMode2D.Impulse);
    }

}

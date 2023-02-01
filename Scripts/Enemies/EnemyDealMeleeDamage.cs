using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDealMeleeDamage : DealDamage, IDealDamage
{
    [SerializeField] private UnityEvent onDealDamageStart;
    void Update()
    {
        var isTarget = Physics2D.OverlapCapsuleAll(rangeDamage.transform.position, rangeDamage.size,
            CapsuleDirection2D.Horizontal, 0, takeMeleeDamageMask).Any();
        
        canAttack = isTarget;

        if (isTarget)
        {
            InvokeDealDamage();
        }
    }


    public void InvokeDealDamage()
    {
        onDealDamageStart.Invoke();
    }
}

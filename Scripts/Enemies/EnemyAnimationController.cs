using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimationController : AnimationController
{
    
    [SerializeField] private PatrolLeftRight patrolLeftRight;
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private UnityEvent onAttackEnd;
    [SerializeField] private UnityEvent onDuringAttack;
    private void LateUpdate()
    { 
        animator.SetFloat("xMove",patrolLeftRight.MoveXSpeed);   
        animator.SetBool("isDeath",enemyHealth.IsDeath);   
        animator.SetBool("canAttack",dealMeleeDamage.CanAttack);
    }

    private void InvokeOnAttackEnd()
    {
        onAttackEnd.Invoke();
    }
    
    private void InvokeOnDuringAttack()
    {
        onDuringAttack.Invoke();
    }

    public void SetBoolInAnimatorOnFalse(string animatorVariable)
    {
        animator.SetBool(animatorVariable,false);   
    }
    
    public void SetBoolInAnimatorOnTrue(string animatorVariable)
    {
        animator.SetBool(animatorVariable,true);     
    }

}

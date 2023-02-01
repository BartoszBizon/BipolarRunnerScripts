using System.Linq;
using UnityEngine;

public class PlayerDealMeleeDamage : DealDamage ,IDealDamage
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private int maximumCombo;
    [SerializeField] private float attackComboCooldown;
    [SerializeField] private AudioClip[] attackSounds;
    private float timeElapsed;
    private int attackCombo;
    public int AttackCombo => attackCombo;
    
    public void Update()
    {
        if (attackCombo <= 0)
            return;
        
        timeElapsed += Time.fixedDeltaTime;
        
        if (timeElapsed >= attackComboCooldown)
        {
            ResetCombo();

            timeElapsed = 0;
        }
    }

    private void ResetCombo()
    {
        attackCombo = 0;
    }

    public void InitAttack()
    {
        if (!canAttack)
            return;
        
        if (AttackCombo >= maximumCombo)
            ResetCombo();
        
        if (!groundCheck.IsGrounded)
            ResetCombo();
        
        
        canAttack = false;
        InvokeDealDamage();
        
        AudioManager.Instance.EffectsAudioSource.PlayOneShot(attackSounds[attackCombo]);
        attackCombo++;
        timeElapsed = 0;
    }

    public void InvokeDealDamage()
    {
        var damage = playerController.Damage;
        var targets = Physics2D.OverlapCapsuleAll(transform.position,rangeDamage.size,CapsuleDirection2D.Horizontal,0,takeMeleeDamageMask)
            .Select(x => x.GetComponent<TakeDamage>()).ToArray();

        foreach (var target in targets)
        {
            if (target.Health.HealthValue > 0)
            {
                
                target.Health.OnHealthValueChange(damage);
            
                int xOrientation = target.transform.position.x > transform.position.x ? 1 : -1;
                var force = new Vector2(xOrientation * 3,3);
                target.AddForce(force);
            }
        }
    }

}
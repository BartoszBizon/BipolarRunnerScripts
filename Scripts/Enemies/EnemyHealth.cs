using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private EnemyCore enemyCore;
    
    [SerializeField] 
    private int healthValue;

    public int HealthValue => healthValue;

    [SerializeField] 
    private TakeHitEffect takeHitEffect;

    [SerializeField] 
    private EnemyHealthBar healthBar;

    [SerializeField] 
    private UnityEvent onDeath;

    private bool isDeath;
    public bool IsDeath => isDeath;

    public void OnHealthValueChange(int value)
    {
        takeHitEffect.TakeHit(1);
        healthValue -= value;
        
        healthBar.RefreshHealthBar(healthValue);
        
        if (healthValue <= 0)
        {
            isDeath = true;
            onDeath.Invoke();
        }
    }

}

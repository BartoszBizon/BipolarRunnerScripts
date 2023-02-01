using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TransformJump : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private Vector3 endValue;
    [SerializeField] private float jumpPower;
    [SerializeField] private int numberOfJumps;
    [SerializeField] private float duration;
    public int EndValueMultiplier { get; set; }

    public void DoJump()
    {
        if(enemyHealth.IsDeath)
            return;
        
        var multiplier = EndValueMultiplier == 0 ? 1 : EndValueMultiplier;
        var targetPlace = (endValue * multiplier) + targetTransform.position;
        targetTransform.DOJump(targetPlace, jumpPower,numberOfJumps,duration);
    }

}

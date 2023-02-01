using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class DealDamageFromJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float upForce;
    [SerializeField] private bool canAddForce;
    [SerializeField] private AudioClip jumpDamageSound;
    [SerializeField] private UnityEvent onDealDamage;

    public bool CanAddForce
    {
        set => canAddForce = value;
    }

        private void OnTriggerEnter2D(Collider2D other)
    {
        if (canAddForce && other.transform.CompareTag("TakeJumpDamage"))
        {
            if (other.transform.position.y < transform.position.y)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x,0);
                playerRigidbody.AddForce(new Vector2(0f, upForce));
                other.GetComponent<TakeDamage>().Health.OnHealthValueChange(1);
                canAddForce = false;
                AudioManager.Instance.EffectsAudioSource.PlayOneShot(jumpDamageSound);
                onDealDamage.Invoke();
            }
        }
    }
    
}

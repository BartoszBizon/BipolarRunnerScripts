using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private CapsuleCollider2D groundCheck;
    [SerializeField] private CapsuleCollider2D groundVerticalCheck;
    [SerializeField] private LayerMask layerGround;


    private bool isGrounded;
    public bool IsGrounded => isGrounded;
    
    private bool isGroundVertical;
    public bool IsGroundVertical => isGroundVertical;
    

    private void FixedUpdate()
    {
        var ground = Physics2D.OverlapCapsuleAll(transform.position, groundCheck.size, CapsuleDirection2D.Horizontal, 0, layerGround);

        isGrounded = ground.Any();

        if (isGrounded)
        {
            playerController.ResetJumpCounter();
        }
    }




}

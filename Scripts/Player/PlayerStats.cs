using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField] private int damage;
    public int Damage => damage;
    
    [SerializeField] private float jumpPower;
    public float JumpPower => jumpPower;

    [SerializeField] private bool canDoubleJump;
    public bool CanDoubleJump => canDoubleJump;

}

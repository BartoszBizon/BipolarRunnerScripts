using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Current Skin", menuName = "ScriptableObjects/Current Skin", order = 1)]
public class CurrentSkin : ScriptableObject
{
    [SerializeField] private Material skinMaterial;

    public Material SkinMaterial
    {
        get => skinMaterial;
        set => skinMaterial = value;
    }
}

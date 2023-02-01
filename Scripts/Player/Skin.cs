using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CurrentSkin currentSkin;

    private Material skinMaterial;
    void Start()
    {
        spriteRenderer.material = currentSkin.SkinMaterial;
        skinMaterial = currentSkin.SkinMaterial;
    }
    
    void Update()
    {
        skinMaterial.mainTexture = spriteRenderer.sprite.texture;
    }
}

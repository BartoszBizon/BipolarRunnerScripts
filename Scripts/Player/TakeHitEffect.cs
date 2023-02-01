using DG.Tweening;
using EZCameraShake;
using UnityEngine;

public class TakeHitEffect : MonoBehaviour
{
    [SerializeField] private Material hitedWhite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private Color lowerAlpha;
    private Color defaultColor;
    private Sequence sequence;
    private Material defaultMaterial;

    private void Start()
    {
        defaultMaterial = spriteRenderer.material;
        defaultColor = spriteRenderer.color;
        lowerAlpha = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 0.1f);
    }
    

    public void TakeHit(int time)
    {
        sequence = DOTween.Sequence();

        spriteRenderer.material = hitedWhite;

        sequence.AppendInterval(0.1f).AppendCallback(SetMaterialToDefault);

        for (int i = 0; i < time; i++)
        {
            sequence.Append(spriteRenderer.DOColor(lowerAlpha, 0.15f));
            sequence.Append(spriteRenderer.DOColor(defaultColor, 0.15f));
        }
    }
    
    private void SetMaterialToDefault()
    {
        spriteRenderer.material = defaultMaterial;
    }
    
}

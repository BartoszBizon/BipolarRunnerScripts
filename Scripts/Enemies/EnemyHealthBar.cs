using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> hearts;

    [SerializeField] private Color fadedColor = new Color(255,255,255,0);
    [SerializeField] private Color visibleColor = new Color(255,255,255,255);

    private void Awake()
    {
        transform.parent = null;
    }

    public void RefreshHealthBar(int healthValue)
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < healthValue)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        
        ShowHealthBar();
    }

    public void ShowHealthBar()
    {
        foreach (var heart in hearts)
        {
            heart.DOColor(visibleColor, 1).OnComplete(() => { heart.DOColor(fadedColor, 1); });
        }
    }

}

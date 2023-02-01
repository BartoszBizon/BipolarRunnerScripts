using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private float endAlphaValue;
    [SerializeField] private Image background;
    [SerializeField] private Image character;
    [SerializeField] private TextMeshProUGUI loadingText;


    public void ShowLoadingScreen()
    {
        DOTween.To(() => background.color, x => background.color = x, new Color(background.color.r,background.color.g,background.color.b,endAlphaValue), duration);
        DOTween.To(() => character.color, x => character.color = x, new Color(character.color.r,character.color.g,character.color.b,endAlphaValue), duration);
        DOTween.To(() => loadingText.color, x => loadingText.color = x, new Color(loadingText.color.r,loadingText.color.g,loadingText.color.b,endAlphaValue), duration);
    }
}

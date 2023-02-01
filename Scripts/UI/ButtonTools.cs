using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonTools : MonoBehaviour
{
    public void RefreshButtonInteractable(Button button)
    {
        var counter = 0;
        button.enabled = false;
        DOTween.To(()=> counter, x=> counter = x, 1, 0.1f).OnComplete(() => { button.enabled = true;});

    }

    public void InvokeOnClick(Button button)
    {
        button.onClick.Invoke();
    }
}

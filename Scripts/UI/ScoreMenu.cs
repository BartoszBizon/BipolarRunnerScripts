using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class ScoreMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreValue;
    
    private DistanceController distanceController;

    [Inject]
    public void Init(DistanceController distanceController)
    {
        this.distanceController = distanceController;
    }
    private void OnEnable()
    {
        Time.timeScale = 0;
        scoreValue.SetText(string.Format("{0}",distanceController.ActualDistance));
    }

}


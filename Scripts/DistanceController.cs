using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DistanceController : MonoBehaviour
{
    private PlayerController playerController;
    private CanvasManager canvasManager;
    private float actualDistance = 0;
    public float ActualDistance => actualDistance;
    
    [Inject]
    public void Init(PlayerController playerController, CanvasManager canvasManager)
    {
        this.playerController = playerController;
        this.canvasManager = canvasManager;
    }
    
    private void SetActualDistance()
    {
        var positionX = (int)playerController.transform.position.x;
        var newDistance = positionX > actualDistance  ? positionX : actualDistance;
        actualDistance = newDistance;
        
        canvasManager.DistancePanel.DistanceValue.SetText(string.Format("{0}",actualDistance));
    }

    public void LateUpdate()
    {
        SetActualDistance();
    }
}

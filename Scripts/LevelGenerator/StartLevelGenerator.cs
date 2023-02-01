using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelGenerator : MonoBehaviour
{
    [SerializeField] private DynamicLevelGenerator levelGenerator;
    [SerializeField] private CameraMovementController cameraMovementController;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        levelGenerator.enabled = true;
        cameraMovementController.enabled = true;
    }
}

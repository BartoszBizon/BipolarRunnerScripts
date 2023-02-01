using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraMovementController : MonoBehaviour
{


    public static CameraMovementController Instance { get; private set; }
    
    [SerializeField] private Transform cameraTransform;

    private float cameraXOffset; 
    private PlayerController playerController;

    public Transform CameraTransform => cameraTransform;

    [Inject]
    public void Init(PlayerController playerController)
    {
        this.playerController = playerController;
    }
    private void Start()
    {
        cameraXOffset = cameraTransform.position.x - playerController.transform.position.x;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(this);
        }
    }

    private void FixedUpdate()
    {
        cameraTransform.position = new Vector3(playerController.transform.position.x+cameraXOffset, cameraTransform.position.y,cameraTransform.position.z);
    }
}

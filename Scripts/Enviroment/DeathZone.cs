using System;
using UnityEngine;
using Zenject;

public class DeathZone : MonoBehaviour
{
    private Transform mainCamera;
    
    [Inject]
    private GameManager gameManager;
    private void Start()
    {
        mainCamera = gameManager.MainCamera.transform;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(mainCamera.position.x,transform.position.y,transform.position.z);
    }
}

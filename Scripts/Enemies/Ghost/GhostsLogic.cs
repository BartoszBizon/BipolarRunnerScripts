using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GhostsLogic : MonoBehaviour
{
    [SerializeField] private Color targetColorDark;
    [SerializeField] private Color transparentColor;
    [SerializeField] private int distanceBetweenGhostSequences;
    [SerializeField] private GhostSequence[] ghostSequences;

    private Image foregroundDark;
    private DistanceController distanceController;
    private PlayerController playerController;
    private CanvasManager canvasManager;
    private int multiplier = 1;
    private float defaultMusicVolumeValue;

    [Inject]
    public void Init(PlayerController playerController, DistanceController distanceController,CanvasManager canvasManager)
    {
        this.distanceController = distanceController;
        this.playerController = playerController;
        this.canvasManager = canvasManager;
    }
    
    void Start()
    {
        foregroundDark = canvasManager.ForegroundDark;
    }

    private void Update()
    {
        if (distanceController.ActualDistance > distanceBetweenGhostSequences * multiplier)
        {
            EnableGhostMode();
        }

        if (distanceController.ActualDistance - ghostSequences[0].EndPositionOfSequence.position.x > 8)
        {
            DisableGhostMode();
        }
    }

    private void EnableGhostMode()
    {
        AudioManager.Instance.SmoothSetMusicVolume(0.2f);
        var playerPositionX = playerController.transform.position.x;
        transform.position = new Vector3(playerPositionX + 10, 0);
        multiplier++;
        foregroundDark.color = transparentColor;
        foregroundDark.gameObject.SetActive(true);
        ghostSequences[0].gameObject.SetActive(true);
        DOTween.To(() => foregroundDark.color, x=>foregroundDark.color = x, targetColorDark, 2);
    }

    public void DisableGhostMode()
    {
        ghostSequences[0].gameObject.SetActive(false);
        AudioManager.Instance.SmoothSetMusicVolume(1);
        DOTween.To(() => foregroundDark.color, x=>foregroundDark.color = x, transparentColor, 2);
    }
    
}

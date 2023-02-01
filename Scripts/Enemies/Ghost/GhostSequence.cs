using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GhostSequence : MonoBehaviour
{
    public Transform EndPositionOfSequence => endPositionOfSequence;
    
    [SerializeField] private Transform[] ghostTransforms;
    [SerializeField] private Transform endPositionOfSequence;

    private Vector2[] startPositions;

    private void Awake()
    {
        startPositions = new Vector2[ghostTransforms.Length];
        
        for (int i = 0; i < ghostTransforms.Length; i++)
        {
            startPositions[i] = ghostTransforms[i].localPosition;
        }
    }

    private void OnEnable()
    {
        MoveSlalom();
    }
    
    private void MoveSlalom()
    {
        transform.localPosition = new Vector2(0,0);
        for (int i = 0; i < ghostTransforms.Length; i++)
        {
            ghostTransforms[i].localPosition = startPositions[i];
            var yMoveValue = i % 2 == 0 ? 2 : -2;

            ghostTransforms[i].DOBlendableLocalMoveBy(new Vector2(0, yMoveValue), 3f).SetEase(Ease.OutSine).SetLoops(4, LoopType.Yoyo);
        }
    }
    private void Update()
    {
        transform.Translate(new Vector2(-1,0) * Time.deltaTime);
    }
}

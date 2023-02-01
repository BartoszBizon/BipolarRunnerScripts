using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPart : MonoBehaviour
{
    [SerializeField]
    private Transform startOfLevelPart;
    public Transform StartOfLevelPart => startOfLevelPart;

    [SerializeField]
    private Transform endOfLevelPart;
    public Transform EndOfLevelPart => endOfLevelPart;


}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceUI : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI distanceValue;

    public TextMeshProUGUI DistanceValue
    {
        get => distanceValue;
        set => distanceValue = value;
    }
}

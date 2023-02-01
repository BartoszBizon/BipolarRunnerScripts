using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnRandomGameObject : MonoBehaviour
{
            
    [Tooltip("Sum Of all percentage Chances must be equal 100")] 
    [SerializeField] private GameObjectValues[] objectsToSpawn;
    
    

    private void Start()
    {
        SetAllPercentageValues();
        var randomNumber = Random.Range(0, 100);
        var randomObject = GetObjectByRange(randomNumber);

        Instantiate(randomObject,transform.position,Quaternion.identity);
    }

    [Serializable]
    private class GameObjectValues
    {
        [SerializeField] private GameObject gameObjectValue;
        public GameObject GameObjectValue => gameObjectValue;
        
        [SerializeField] private int percentageChance;
        public int PercentageChance => percentageChance;

        private int minRangeValue;

        public int MinRangeValue
        {
            get => minRangeValue;
            set => minRangeValue = value;
        }
        
        private int maxRangeValue;

        public int MaxRangeValue
        {
            get => maxRangeValue;
            set => maxRangeValue = value;
        }
    }

    private void SetAllPercentageValues()
    {
        var minValue = 0;

        foreach (var objectToSpawn in objectsToSpawn)
        {
            objectToSpawn.MinRangeValue = minValue;
            var maxValue = minValue + objectToSpawn.PercentageChance;
            objectToSpawn.MaxRangeValue = maxValue;
            minValue = maxValue;
        }
    }

    private GameObject GetObjectByRange(int number)
    {
        foreach (var objectToSpawn in objectsToSpawn)
        {
            if (number >= objectToSpawn.MinRangeValue && number <= objectToSpawn.MaxRangeValue)
            {
                return objectToSpawn.GameObjectValue;
            }
        }

        return null;
    }

}

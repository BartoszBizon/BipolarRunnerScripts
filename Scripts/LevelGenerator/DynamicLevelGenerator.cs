using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DynamicLevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform allPartsParent;
    [SerializeField] private LevelPart[] availableLevelParts;
    [SerializeField] private float maximumDistanceBetweenParts;
    [SerializeField] private float distanceToDestroyPart;

    private PlayerController playerController;
    private LevelPart lastSpawnedPart;
    private List<GameObject> levelParts;
    private int minPartsAmount => 2;

    [Inject]
    public void Init(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    private void Start()
    {
        levelParts = new List<GameObject>();
        SpawnFirstPart();
    }

    private void Update()
    {
        if (playerController.transform.position.x > lastSpawnedPart.StartOfLevelPart.position.x)
        {
            SpawnNewPart();
        }
        
        var levelPartsCount = levelParts.Count;
        var distanceToFarestPart = Vector2.Distance(levelParts[0].transform.position, playerController.transform.position);
        if (levelPartsCount > minPartsAmount && distanceToFarestPart > distanceToDestroyPart)
        {
            var lastPart = levelParts[0].gameObject;
            levelParts.RemoveAt(0);
            Destroy(lastPart);
        }
    }

    private void SpawnFirstPart()
    {
        lastSpawnedPart = Instantiate(availableLevelParts[0], transform.position,Quaternion.identity);
        levelParts.Add(lastSpawnedPart.gameObject);
    }

    private void SpawnNewPart()
    {
        var distanceBetweenParts = Random.Range(1, maximumDistanceBetweenParts);
        var randomPart = availableLevelParts[Random.Range(0, availableLevelParts.Length)];
        var halfOfLevelPart = Vector2.Distance(randomPart.StartOfLevelPart.position , randomPart.EndOfLevelPart.position)/2;
        var newPosition = (Vector2)lastSpawnedPart.EndOfLevelPart.position + new Vector2(distanceBetweenParts + halfOfLevelPart,0);;

        
        lastSpawnedPart = Instantiate(randomPart, newPosition,Quaternion.identity);
        lastSpawnedPart.transform.SetParent(allPartsParent);
        levelParts.Add(lastSpawnedPart.gameObject);
    }

}

using UnityEngine;
using Zenject;

public class StartPlace : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    
    [Inject] private PlayerController playerController;
    void Start()
    {
        playerController.transform.position = spawnPoint.position;
    }
    
}

using UnityEngine;

public class BackgroundLayer : MonoBehaviour
{
    [SerializeField] 
    private SpriteRenderer spriteRenderer;
    
    private float startPosition;
    public float StartPosition => startPosition;
    public float SpriteLength => spriteRenderer.bounds.size.x;

    public bool debug;

    private void Start()
    {
        startPosition = transform.position.x;
        if (debug)
        {
            Debug.Log(startPosition);
        }
    }

    public void IncreaseStartPositionByLength()
    {
        startPosition += SpriteLength * 3;
    }
    
}

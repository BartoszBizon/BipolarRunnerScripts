using UnityEngine;
using UnityEngine.Events;
public class Timer : MonoBehaviour
{
    [SerializeField]
    private float duration = 1f;

    public float Duration
    {
        get => duration;
        set => duration = value;
    }

    public UnityEvent onFinish;

    private float elapsed = 0;

    void Update()
    {
        if (elapsed < duration)
        {
            elapsed += Time.deltaTime;
        }
        else
        {
            enabled = false;
            onFinish.Invoke();
        }
    }

    public void Restart()
    {
        elapsed = 0;
        enabled = true;
    }

    public void Start()
    {
        enabled = true;
    }

    public void Pause()
    {
        enabled = false;
    }

    public void SetDuration(float newDuration) 
    {
        duration = newDuration;
    }

    public float GetProgress() 
    {
        var progress = elapsed / duration;
        return progress;
    }

    public float GetReversedProgress()
    {
        var reversedProgress = (duration - elapsed) / duration;
        return reversedProgress;
    }
}

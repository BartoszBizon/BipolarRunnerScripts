using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class EventsList : MonoBehaviour
{
    [SerializeField] private List<UnityEvent> events;

    public void Execute()
    {
        for (int i = 0; i < events.Count; i++)
        {
            events[i].Invoke();
        }
    }
}

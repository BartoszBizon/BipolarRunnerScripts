using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoBehavioursEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent onEnable;
    [SerializeField] private UnityEvent onDisable;
    [SerializeField] private UnityEvent onStart;
    [SerializeField] private UnityEvent onAwake;
    [SerializeField] private UnityEvent onDestroy;

    private void Awake()
    {
        onAwake.Invoke();
    }

    private void Start()
    {
        onStart.Invoke();
    }

    private void OnEnable()
    {
        onEnable.Invoke();
    }

    private void OnDisable()
    {
        onDisable.Invoke();
    }

    private void OnDestroy()
    {
        onDestroy.Invoke();
    }
}

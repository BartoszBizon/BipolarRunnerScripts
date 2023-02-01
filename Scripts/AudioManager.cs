using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource effectsAudioSource;
    [SerializeField] private AudioClip[] clipsOnLevelStart;
    [SerializeField] private AudioClip[] clipsOnRestGameplay;
    [SerializeField] private Timer timer;
    
    private float audioClipTime;

    public AudioSource MusicAudioSource => musicAudioSource;
    public AudioSource EffectsAudioSource => effectsAudioSource;
    
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }	
    }

    void Start()
    {
        musicAudioSource.clip = clipsOnLevelStart[Random.Range(0, clipsOnLevelStart.Length)];
        audioClipTime = musicAudioSource.clip.length;
        musicAudioSource.Play();
        ResetTimerWithNewTime();
        
    }

    public void ResetTimerWithNewTime()
    {
        timer.Duration = audioClipTime;
        timer.Restart();
    }
    
    public void SetRandomClip()
    {
        musicAudioSource.clip = clipsOnRestGameplay[Random.Range(0, clipsOnRestGameplay.Length)];
        audioClipTime = musicAudioSource.clip.length;
        musicAudioSource.Play();
    }

    public void SmoothSetMusicVolume(float targetVolume)
    {
        DOTween.To(() => musicAudioSource.volume, x=>musicAudioSource.volume = x, targetVolume, 1);
    }
}

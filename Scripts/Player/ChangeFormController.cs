using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ChangeFormController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private int darkEssenceToChangeAmount;
    [SerializeField] private bool canChange;
    [SerializeField] private float darkFormTime;
    [SerializeField] private PlayerStats lightFormStats;
    [SerializeField] private PlayerStats darkFormStats;
    [SerializeField] private AnimationEvents animationEvents;
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private AudioClip changeFormSound;

    private bool duringTransformation;
    public bool DuringTransformation
    {
        get => duringTransformation;
        set => duringTransformation = value;
    }
    
    private LightOrDark currentForm;
    public LightOrDark CurrentForm => currentForm;
    
    private int changeFormEssenceCounter;
    private CanvasManager canvasManager;
    private Slider darkEssenceFill;
    
    [Inject]
    public void Init(CanvasManager canvasManager)
    {
        this.canvasManager = canvasManager;
    }
    private void Start()
    {
        darkEssenceFill = canvasManager.DarkEssenceFill;
        playerController.AssignPlayerStats(lightFormStats);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("DarkEssence"))
        {
            if (currentForm == LightOrDark.Light)
                IncrementDarkEssence();
        }
    }

    private void IncrementDarkEssence()
    {
        if (darkEssenceToChangeAmount > changeFormEssenceCounter)
        {
            changeFormEssenceCounter++;

            var darkEssenceFillValue = darkEssenceFill.value;
            var finalValue = darkEssenceFillValue + 0.25f;
            DOTween.To(() => darkEssenceFill.value, x => darkEssenceFill.value = x, finalValue, 1f);

            if(darkEssenceToChangeAmount == changeFormEssenceCounter)
            {
                canChange = true;
            }
        }
    }

    public void ChangeFormTo(LightOrDark lightOrDark)
    {
        if(!canChange || !groundCheck.IsGrounded || duringTransformation)
            return;
        
        DOTween.To(()=>Time.timeScale,x => Time.timeScale = x, 0.2f,0.1f).OnComplete(() =>
        {
            AudioManager.Instance.EffectsAudioSource.PlayOneShot(changeFormSound);
        });
        playerController.AssignPlayerStats(darkFormStats);
        currentForm = lightOrDark;
        changeFormEssenceCounter = 0;
        duringTransformation = true;
        canChange = false;
        StartDarkCounter();
    }

    private void StartDarkCounter()
    {
        DOTween.To(() => darkEssenceFill.value, x => darkEssenceFill.value = x, 0, darkFormTime).OnComplete(() =>
        {
            duringTransformation = true;
            animationEvents.PlayAnimationEffect("DoEffect1");
            playerController.AssignPlayerStats(lightFormStats);
            currentForm = LightOrDark.Light;
            AudioManager.Instance.EffectsAudioSource.PlayOneShot(changeFormSound);
        });
    }

}

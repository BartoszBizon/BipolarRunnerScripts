using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public static TouchController Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    private bool getJumpDown;
    private bool getJump;
    private bool getJumpUp;
    private bool changeForm;
    private bool attack;
    private bool pause;

    public bool GetJumpDown
    {
        get => getJumpDown;
        set => getJumpDown = value;
    }
    public bool GetJump
    {
        get => getJump;
        set => getJump = value;
    }

    public void SetGetJumpDownTrueForOneFrame()
    {
        StartCoroutine(SetFalseAfterOneFrameJumpDown());
    }
    
    public void SetGetJumpUpTrueForOneFrame()
    {
        StartCoroutine(SetFalseAfterOneFrameJumpUp());
    }

    private IEnumerator SetFalseAfterOneFrameJumpDown()
    {
        getJumpDown = true;
        yield return new WaitForEndOfFrame();
        getJumpDown = false;
    }
    
    private IEnumerator SetFalseAfterOneFrameJumpUp()
    {
        getJumpUp = true;
        yield return new WaitForEndOfFrame();
        getJumpUp = false;
    }

    public bool ChangeForm
    {
        get => changeForm;
        set => changeForm = value;
    }

    public bool Attack
    {
        get => attack;
        set => attack = value;
    }

    public bool Pause
    {
        get => pause;
        set => pause = value;
    }

    public bool GetBoolByName(string boolName)
    {
        switch (boolName)
        {
            case "getJumpDown":
                return getJumpDown;
            case "getJump":
                return getJump;
            case "getJumpUp":
                return getJumpUp;
            case "changeForm":
                return changeForm;
            case "attack":
                return attack;
            case "pause":
                return pause;
            default: return false;
        }
    }
}

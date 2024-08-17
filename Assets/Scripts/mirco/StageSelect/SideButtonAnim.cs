using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SideButtonAnim : MonoBehaviour
{
    [Header("AnimSetting")] 
    [SerializeField] private float moveX;
    [SerializeField] private float tweenTime;

    private void Start()
    {
        StandbyAnim();
    }

    void StandbyAnim()
    {
        LeanTween.moveLocalX(this.gameObject, moveX, tweenTime).setEaseInOutSine().setLoopPingPong();
    }
}


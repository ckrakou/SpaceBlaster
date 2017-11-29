﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SplashScreenJuice : MonoBehaviour {

    public float FadeTime = 1.0f;

    private Image splashScreen;
	// Use this for initialization
	void Start () {
        splashScreen = GetComponent<Image>();
        FadeIn();
	}

    public void FadeIn()
    {
        splashScreen.DOKill();
        splashScreen.DOFade(1, FadeTime);
    }

    public void FadeOut()
    {
        splashScreen.DOKill();
        splashScreen.DOFade(0, FadeTime);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class SplashScreenJuice : MonoBehaviour {

    public float FadeTime = 1.0f;
    [Range(1,100)]
    public int DarkenedPercentage = 75;

    private Image splashScreen;
    private bool oscilating = false;
	// Use this for initialization
	void Start () {
        splashScreen = GetComponent<Image>();
        FadeIn();
	}

    public void FadeIn()
    {
        splashScreen.DOKill();
        splashScreen.DOFade(1, FadeTime).onComplete = new TweenCallback(StartOscilating);

    }

    public void FadeOut()
    {
        splashScreen.DOKill();
        splashScreen.DOFade(0, FadeTime).onComplete = new TweenCallback(StopOscilating);
    }

    private void StartOscilating()
    {
        Sequence colorShift = DOTween.Sequence();
        colorShift.Append(splashScreen.DOColor(new Color(DarkenedPercentage / 100f, DarkenedPercentage / 100f, DarkenedPercentage / 100f), 0.5f));
        colorShift.Append(splashScreen.DOColor(Color.white, 0.5f));
        colorShift.SetLoops(-1, LoopType.Yoyo);
    }

    private void StopOscilating()
    {
        splashScreen.color = Color.white;
    }
}

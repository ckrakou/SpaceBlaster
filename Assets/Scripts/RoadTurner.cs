﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RoadTurner : MonoBehaviour {

    public float DegreesPerTurn = 40f;
    public float SecondsPerTurn = 0.2f;

    Vector3 currentEulerRotation;

	// Use this for initialization
	void Start () {
        currentEulerRotation = transform.rotation.eulerAngles;
	}

    // Update is called once per frame
    void Update()
    {

    }
	
    public void TurnLeft()
    {
        DOTween.Kill(transform);
        currentEulerRotation += new Vector3(0, 0, 40);
        transform.DORotate(currentEulerRotation, SecondsPerTurn, RotateMode.Fast);
    }

    public void TurnRight()
    {
        DOTween.Kill(transform);
        currentEulerRotation += new Vector3(0, 0, -40);
        transform.DORotate(currentEulerRotation, SecondsPerTurn, RotateMode.Fast);
    }
}

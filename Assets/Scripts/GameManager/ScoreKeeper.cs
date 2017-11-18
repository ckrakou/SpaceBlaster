using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public bool Debugging;
    [Header("GUI Elements")]
    public Text TextElement;
    [Header("Points Awarded")]
    public int PointsPerPassedSection = 10;
    public int PointsPerShotFence = 20;

    // internal variables
    private int score;
    private bool guiSynced = false;

    public int Score
    {
        get
        {
            return score;
        }
    }

    // Use this for initialization
    void Start () {
        UpdateGUI();
	}

    // Update is called once per frame
    void Update () {
        if (guiSynced == false)
        {
            UpdateGUI();
        }
	}

    public void PassedSection()
    {
        if (Debugging)
        {
            Debug.Log("ScoreKeeper: Adding points for passing section");
        }
        score += PointsPerPassedSection;
        guiSynced = false;

    }

    public void ShotFence()
    {
        if (Debugging)
        {
            Debug.Log("ScoreKeeper: Adding points for shooting fence");
        }
        score += PointsPerShotFence;
        guiSynced = false;

    }

    internal void Reset()
    {
        if (Debugging)
        {
            Debug.Log("ScoreKeeper: Resetting Score");
        }
        score = 0;
        guiSynced = false;
    }

    private void UpdateGUI()
    {
        if (Debugging)
        {
            Debug.Log("ScoreKeeper: Updating Score Text");
        }
        TextElement.text = "Score: " + Score;
        guiSynced = true;
    }

}

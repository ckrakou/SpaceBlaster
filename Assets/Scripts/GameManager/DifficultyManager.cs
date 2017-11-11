using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{

    public DifficultyLevel[] DifficultyLevels;
    public int PointsThreshold;

    private TileSpawner spawner;
    private ScoreKeeper score;
    private int currentDifficulty;

    // Use this for initialization
    void Start()
    {
        spawner = GetComponent<TileSpawner>();
        score = GetComponent<ScoreKeeper>();
        SetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        if (score.Score > PointsThreshold && currentDifficulty < DifficultyLevels.Length - 1)
        {
            currentDifficulty++;
            PointsThreshold += PointsThreshold;
            SetDifficulty();
        }
    }

    private void SetDifficulty()
    {
        spawner.SpawnInterval = DifficultyLevels[currentDifficulty].Interval;
        spawner.TileSpeed = DifficultyLevels[currentDifficulty].Speed;
        spawner.UpdateExistingTiles();
    }

}

[System.Serializable]
public struct DifficultyLevel
{
    public float Interval;
    public float Speed;
}


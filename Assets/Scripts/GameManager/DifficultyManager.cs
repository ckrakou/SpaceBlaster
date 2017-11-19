using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{

    public int PointsThreshold = 150;

    [Header("Initial Difficulty")]
    public float InitialSpawnRate = 2.5f;
    public float InitialSpeed = 20;

    [Header("Difficulty Elements, as Percentages")]
    [Range(0, 1)]
    public float SpawnRateIncrease = 0.1f;
    [Range(0,1)]
    public float SpeedIncrease = 0.1f;
    
    private TileSpawner spawner;
    private ScoreKeeper score;
    private DifficultyLevel currentDifficulty;

    // Use this for initialization
    void Start()
    {
        spawner = GetComponent<TileSpawner>();
        score = GetComponent<ScoreKeeper>();
        currentDifficulty = new DifficultyLevel(InitialSpawnRate, InitialSpeed, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (score.Score > PointsThreshold * currentDifficulty.Difficultylevel)
        {
            IncreaseDifficulty(currentDifficulty.Difficultylevel);
            SetDifficulty();
        }
    }

    private void IncreaseDifficulty(int currentLevel)
    {
        currentDifficulty = new DifficultyLevel(
            InitialSpawnRate - (currentLevel + 1 * SpawnRateIncrease),
            InitialSpeed + (currentLevel + 1 * SpeedIncrease),
            currentLevel + 1);
    }

    private void SetDifficulty()
    {
        spawner.SpawnInterval = currentDifficulty.SpawnInterval;
        spawner.TileSpeed = currentDifficulty.Speed;
        spawner.UpdateExistingTiles();
    }

    private struct DifficultyLevel
    {
        public float SpawnInterval;
        public float Speed;
        public int Difficultylevel;

        public DifficultyLevel(float spawnInterval, float speed, int difficultylevel)
        {
            SpawnInterval = spawnInterval;
            Speed = speed;
            Difficultylevel = difficultylevel;
        }
    }
}




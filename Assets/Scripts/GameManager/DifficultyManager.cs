using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

    public DifficultyLevel[] DifficultyLevels;
    public float PointsThreshold;

    private TileSpawner spawner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}

[System.Serializable]
public struct DifficultyLevel
{
    public float DistanceBetweenSpawns;
    public float Speed;
}


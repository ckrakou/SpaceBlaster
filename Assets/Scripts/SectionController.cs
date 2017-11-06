using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionController : MonoBehaviour {

    public bool Debugging;
    public GameObject BlockerPrefab;
    public GameObject FencePrefab;
    [Range(1,9)]
    public int FilledSpots = 4;
    [Range(0,1)]
    public float BlockerToFenceRatio = 0.5f;

    private ObstacleSpawner[] spawns;

    private void Awake()
    {
        spawns = GetComponentsInChildren<ObstacleSpawner>();

        foreach (var spawn in spawns)
        {
            spawn.Debugging = Debugging;
            spawn.BlockerPrefab = BlockerPrefab;
            spawn.FencePrefab = FencePrefab;
        }

        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        List<int> filledSpots = new List<int>();

        for (int i = 0; i < FilledSpots; i++)
        {
            int index;

            do
            {
                index = UnityEngine.Random.Range(0, spawns.Length);
            } while (filledSpots.Contains(index) == true);

            if (UnityEngine.Random.Range(0f, 1f) >= BlockerToFenceRatio)
            {
                spawns[index].SpawnBlocker();
            }
            else
            {
                spawns[index].SpawnFence();
            }

            filledSpots.Add(index);

        }
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public bool Debugging;

    public GameObject TilePrefab;
    public GameObject Road;
    public Vector3 SpawnPoint;
    public Vector3 KillPoint;

    public float DistanceInterval = 10;
    public float TileSpeed = 5;

    private float nextSpawnTimeStamp;

    // Use this for initialization
    void Start()
    {
        nextSpawnTimeStamp = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTimeStamp)
        {
            if (Debugging)
            {
                Debug.Log("TileSpawner: Spawning new tile. Distance = " + DistanceInterval + " , Speed = " + TileSpeed);
            }
            nextSpawnTimeStamp = Time.time + (DistanceInterval/TileSpeed) - Time.deltaTime;
            TileRunner tile = Instantiate(TilePrefab, SpawnPoint, Road.transform.rotation, Road.transform).GetComponent<TileRunner>();
            tile.Speed = TileSpeed;
            if (Debugging)
            {
                Debug.Log("TileSpawner: Next spawn in " + (nextSpawnTimeStamp - Time.time) + " Seconds");
            }
        }
    }

    internal void UpdateExistingTiles()
    {
        if (Debugging)
        {
            Debug.Log("TileSpawner: Updating speed of " + Road.GetComponentsInChildren<TileRunner>().Length + " tiles to " + TileSpeed);
        }
        foreach (var tile in Road.GetComponentsInChildren<TileRunner>())
        {
            tile.Speed = TileSpeed;
        }
    }
}

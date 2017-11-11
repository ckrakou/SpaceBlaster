using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{

    public GameObject TilePrefab;
    public float TileLength = 10;
    public float TileSpeed = 5;
    public Vector3 SpawnPoint;
    public Vector3 KillPoint;

    private float spawnRate;
    private float nextSpawnTimeStamp;
    private float spawnInterval;

    // Use this for initialization
    void Start()
    {
        nextSpawnTimeStamp = Time.time;
        spawnInterval = TileLength / TileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTimeStamp)
        {
            nextSpawnTimeStamp = Time.time + spawnInterval - Time.deltaTime;
            TileRunner tile = Instantiate(TilePrefab, SpawnPoint, Quaternion.identity, this.transform).GetComponent<TileRunner>();
            tile.Speed = TileSpeed;
        }
    }
}

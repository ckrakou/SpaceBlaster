using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {

    public GameObject TilePrefab;
    public float TileWidth = 10;
    public float GameSpaceWidth = 20;
    public float TileSpeed = 5;

    private Vector3 spawnPoint;
    private float spawnRate;
    private float nextSpawnTimeStamp;
    private float spawnInterval;

	// Use this for initialization
	void Start () {
        spawnPoint = new Vector3((GameSpaceWidth / 2) + (TileWidth / 2), 0, 0);
        nextSpawnTimeStamp = Time.time;
        spawnInterval = TileWidth / TileSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawnTimeStamp)
        {
            Instantiate(TilePrefab, spawnPoint, Quaternion.identity);
            nextSpawnTimeStamp = Time.time + spawnInterval;
        }
	}
}

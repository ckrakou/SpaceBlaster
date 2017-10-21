using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {

    public GameObject[] TilePrefabs;
    public float TileWidth = 10;
    public float GameSpaceWidth = 20;
    public float TileSpeed = 5;

    private Random random;
    private Vector3 spawnPoint;
    private float spawnRate;
    private float nextSpawnTimeStamp;
    private float spawnInterval;

	// Use this for initialization
	void Start () {
        random = new Random();
        spawnPoint = new Vector3((GameSpaceWidth / 2) + (TileWidth / 2), 0, 0);
        nextSpawnTimeStamp = Time.time;
        spawnInterval = TileWidth / TileSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawnTimeStamp)
        {
            int index = Random.Range(0, TilePrefabs.Length - 1);
            Instantiate(TilePrefabs[index], spawnPoint, Quaternion.identity);
            nextSpawnTimeStamp = Time.time + spawnInterval;
        }
	}
}

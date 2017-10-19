using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    public GameObject Asteroid;
    public int MininumAsteroids;
    public int MaximumAsteroids;

    private float radius = 4;
    private bool[] usedSpots;
    private Transform[] spawnPoints;

    // Use this for initialization
    void Start () {
        spawnPoints = transform.GetComponentsInChildren<Transform>();
        usedSpots = new bool[spawnPoints.Length];
        int numberOfAsteroids = UnityEngine.Random.Range(MininumAsteroids, MaximumAsteroids);

        for (int i = 0; i < numberOfAsteroids; i++)
        {
            SpawnAsteroid();
        }
	}

    private void SpawnAsteroid()
    {
        int spot;

        do
        {
            spot = UnityEngine.Random.Range(0, spawnPoints.Length - 1);
        } while (usedSpots[spot] == true);

        Instantiate(Asteroid, spawnPoints[spot].position, Quaternion.identity,this.transform);
        usedSpots[spot] = true;
    }
	
}



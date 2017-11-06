using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public bool Debugging;
    public GameObject BlockerPrefab;
    public GameObject FencePrefab;
    public Transform ObstacleSpot;

    public void SpawnBlocker()
    {
        Instantiate(BlockerPrefab, ObstacleSpot.position, this.transform.rotation, this.transform);
        if (Debugging)
        {
            Debug.Log("ObstacleSpawner: Spawned Blocker");
        }
    }

    public void SpawnFence()
    {
        Instantiate(FencePrefab, ObstacleSpot.position, this.transform.rotation, this.transform);
        if (Debugging)
        {
            Debug.Log("ObstacleSpawner: Spawned Fence");
        }
    }
}

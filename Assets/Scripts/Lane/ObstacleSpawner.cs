﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public bool Debugging;
    public GameObject BlockerPrefab;
    public GameObject FencePrefab;
    public Transform ObstacleSpot;


    // Use this for initialization
    void Start()
    {
        if (Debugging)
        {
            Instantiate(BlockerPrefab, ObstacleSpot.position, this.transform.rotation, this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

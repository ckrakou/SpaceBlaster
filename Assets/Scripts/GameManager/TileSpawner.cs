﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{

    public GameObject TilePrefab;
    public GameObject Road;

    public float SpawnInterval = 10;
    public float TileSpeed = 5;
    public Vector3 SpawnPoint;
    public Vector3 KillPoint;

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
            nextSpawnTimeStamp = Time.time + SpawnInterval - Time.deltaTime;
            TileRunner tile = Instantiate(TilePrefab, SpawnPoint, Quaternion.identity, Road.transform).GetComponent<TileRunner>();
            tile.Speed = TileSpeed;
        }
    }

    internal void UpdateExistingTiles()
    {
        foreach (var tile in Road.GetComponentsInChildren<TileRunner>())
        {
            tile.Speed = TileSpeed;
        }
    }
}

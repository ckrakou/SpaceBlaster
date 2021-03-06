﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControl : MonoBehaviour
{

    public bool Debugging = false;
    [Header("Input Settings")]
    public string ShootButton = "fire1";
    public string MoveAxis = "Horizontal";
    [Header("Scene Settings")]
    public DataCollector dataCollector;
    public Transform LaserSpawnPoint;
    public GameObject BulletPrefab;
    public LaneController InitialLane;

    private bool shotFired = false;
    private bool hasMoved = false;
    private float horizontalOffset;
    private float horizontalReading;
    private Move nextMove = Move.Center;

    private LaneController currentLane;
    private RoadTurner roadTurner;
    private PlayerSound soundEffects;

    // Use this for initialization
    void Start()
    {
        horizontalOffset = Input.GetAxis("Horizontal");

        if (Debugging)
        {
            Debug.Log("Horizontal Offset: " + horizontalOffset);
        }

        currentLane = InitialLane;
        roadTurner = InitialLane.transform.root.GetComponent<RoadTurner>();
        soundEffects = GetComponentInChildren<PlayerSound>();
        MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        FireLaser();
    }

    /*
     * PRIVATE METHODS 
     */

    private void FireLaser()
    {
        if (Input.GetAxis(ShootButton) > 0 && !shotFired)
        {
            if (Debugging)
            {
                Debug.Log("Firing Laser!");
            }

            Instantiate(BulletPrefab, LaserSpawnPoint.position, transform.rotation, currentLane.transform.root);
            soundEffects.Shoot();
            dataCollector.ShotFired();
            shotFired = true;
        }

        if (Input.GetAxis(ShootButton) <= 0)
        {
            shotFired = false;
        }


    }

    private void UpdatePosition()
    {
        ReadInput();
        DetermineNextPosition();
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.position = currentLane.PlayerPosition.position;
        transform.rotation = currentLane.PlayerPosition.rotation;
        Transform road = currentLane.transform.root;
        
        switch (nextMove)
        {
            case Move.Left:
                roadTurner.TurnRight();
                dataCollector.ShipMoved();
                break;
            case Move.Right:
                roadTurner.TurnLeft();
                dataCollector.ShipMoved();
                break;
            case Move.Center:
            default:
                break;
        }

    }

    private void DetermineNextPosition()
    {
        switch (nextMove)
        {
            case Move.Left:
                currentLane = currentLane.LeftTile.GetComponent<LaneController>();
                break;
            case Move.Right:
                currentLane = currentLane.RightTile.GetComponent<LaneController>();
                break;
            case Move.Center:
            default:
                break;
        }
    }

    private void ReadInput()
    {
        float movement = Input.GetAxis(MoveAxis) - horizontalOffset;

        if (Debugging)
        {
            Debug.Log("PlayerControl: Movement Axis = " + movement + ", HasMoved = " + hasMoved);
        }

        if (hasMoved)
        {
            nextMove = Move.Center;
            if (movement == 0)
            {
                hasMoved = false;
            }
        }
        else
        {
            if (movement == 0)
            {
                nextMove = Move.Center;
            }
            else if (movement > 0)
            {
                nextMove = Move.Right;
                hasMoved = true;
            }
            else if (movement < 0)
            {
                nextMove = Move.Left;
                hasMoved = true;
            }
        }
    }

    private enum Move
    {
        Left, Center, Right
    }

}

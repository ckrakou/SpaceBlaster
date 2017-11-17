using System;
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
    public Transform LaserSpawnPoint;
    public GameObject BulletPrefab;
    public LaneController InitialLane;

    private bool shotFired = false;
    private bool hasMoved = false;
    private float horizontalOffset;
    private LaneController currentLane;
    private float horizontalReading;
    private Move nextMove = Move.Center;

    // Use this for initialization
    void Start()
    {
        horizontalOffset = Input.GetAxis("Horizontal");

        if (Debugging)
        {
            Debug.Log("Horizontal Offset: " + horizontalOffset);
        }

        currentLane = InitialLane;
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
        /*
        transform.DOMove(currentLane.PlayerPosition.position, 0.1f);
        transform.DORotateQuaternion(currentLane.PlayerPosition.rotation, 0.1f);
        */
        transform.position = currentLane.PlayerPosition.position;
        transform.rotation = currentLane.PlayerPosition.rotation;
        Transform road = currentLane.transform.root;
        switch (nextMove)
        {
            case Move.Left:
                road.DORotate(currentLane.transform.root.rotation.eulerAngles + new Vector3(0, 0, -40),0.2f);
                //currentLane.transform.root.Rotate(Vector3.forward, -40);
                break;
            case Move.Right:
                road.DORotate(currentLane.transform.root.rotation.eulerAngles + new Vector3(0, 0, 40), 0.2f);
                //currentLane.transform.root.Rotate(Vector3.forward, 40);
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

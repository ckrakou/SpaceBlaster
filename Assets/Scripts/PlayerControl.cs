using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public bool Debugging = false;
    public InputMode inputMode = InputMode.Keyboard;
    public string ShootButton = "fire1";
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;
    public float ObservedMiddleValue = 0.3f;
    public Transform InitialPosition;

    private bool shotFired = false;
    private float horizontalOffset;

    private Vector3 currentPosition;
    private float horizontalReading;
    private Move nextMove;

    // Use this for initialization
    void Start()
    {
        if (inputMode == InputMode.Joystick)
        {
            horizontalOffset = Input.GetAxis("Horizontal");
            if (Debugging)
            {
                Debug.Log("Horizontal Offset: " + horizontalOffset);
            }
        }

        currentPosition = InitialPosition.position;
        transform.position = currentPosition;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        if (Input.GetAxis(ShootButton) > 0 && !shotFired)
        {
            FireLaser();
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
        transform.position = currentPosition;
    }

    private void DetermineNextPosition()
    {
        switch (nextMove)
        {
            case Move.Left:
                break;
            case Move.Right:
                break;
            case Move.Center:
                break;
            default:
                break;
        }
    }

    private void ReadInput()
    {
        switch (inputMode)
        {
            case InputMode.Keyboard:
                ReadKeyboard();
                break;
            case InputMode.Joystick:
                ReadJoystick();
                break;
            default:
                ReadJoystick();
                break;
        }

        if (horizontalReading == 0)
        {
            nextMove = Move.Center;
        }
        else if (horizontalReading == 1)
        {
            nextMove = Move.Right;
        }
        else if (horizontalReading == -1)
        {
            nextMove = Move.Left;
        }
    }

    private void ReadKeyboard()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalReading = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalReading = -1;
        }
        else
        {
            horizontalReading = 0;

        }
    }

    private void FireLaser()
    {
        if (Debugging)
        {
            Debug.Log("Firing Laser!");
        }

        Instantiate(BulletPrefab, BulletSpawnPoint.position, transform.rotation);
        shotFired = true;
    }

    private void ReadJoystick()
    {
        float horizontal = Input.GetAxis("Horizontal") - horizontalOffset;

        if (horizontal == 0)
        {
            horizontalReading = 0;
        }
        else if (horizontal < ObservedMiddleValue)
        {
            horizontalReading = 1;
        }
        else
        {
            horizontalReading = -1;
        }

        if (Debugging)
        {
            Debug.Log("Horizontal Input: " + horizontal + " - " + horizontalReading);
        }
    }

    public enum InputMode
    {
        Keyboard, Joystick
    }

    private enum Move
    {
        Left, Center, Right
    }

}

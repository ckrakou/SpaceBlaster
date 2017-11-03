using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public bool Debugging = false;
    public InputMode inputMode = InputMode.Keyboard;
    public float MovementSpeed = 10;
    public string ShootButton = "fire1";
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;
    public float ObservedMiddleValue = 0.3f;

    private bool shotFired = false;
    private float horizontalOffset;
    private float verticalOffset;

    private float horizontalReading;
    private float verticalReading;

	// Use this for initialization
	void Start () {
		if (inputMode == InputMode.Joystick)
        {
            verticalOffset = Input.GetAxis("Vertical");
            horizontalOffset = Input.GetAxis("Horizontal");
            if (Debugging)
            {
                Debug.Log("Vertical Offset: " + verticalOffset);
                Debug.Log("Horizontal Offset: " + horizontalOffset);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
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
        Vector3 NextPosition = transform.position;
        NextPosition.x += horizontalReading * MovementSpeed * Time.deltaTime;
        NextPosition.z += verticalReading * MovementSpeed * Time.deltaTime;
        transform.position = NextPosition;
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
    }

    private void ReadKeyboard()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalReading = 1;
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalReading = -1;
        }
        else
        {
            verticalReading = 0;
        }
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

        Instantiate(BulletPrefab, BulletSpawnPoint.position ,transform.rotation );
        shotFired = true;
    }

    private void ReadJoystick()
    {
        float horizontal = Input.GetAxis("Horizontal") - horizontalOffset;
        float vertical = Input.GetAxis("Vertical") - verticalOffset;

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

        if (vertical == 0)
        {
            verticalReading = -0;
        }
        else if (vertical > ObservedMiddleValue)
        {
            verticalReading = 1;
        }
        else
        {
            verticalReading = -1;
        }
       

        if (Debugging)
        {
            Debug.Log("Horizontal Input: " + horizontal + " - " + horizontalReading);
            Debug.Log("Vertical Input: " + vertical + " - " + verticalReading);
        }
    }

    public enum InputMode
    {
        Keyboard, Joystick
    }

}

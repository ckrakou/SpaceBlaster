using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public bool Debugging = false;
    public float MovementSpeed = 10;
    public string ShootButton = "fire1";
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdatePosition();
        if (Input.GetAxis(ShootButton) > 0)
        {
            FireLaser();
        }
	}

    private void UpdatePosition()
    {
        Vector3 NextPosition = transform.position;
        NextPosition.x += Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime;
        NextPosition.z += Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;
        transform.position = NextPosition;
    }

    private void FireLaser()
    {
        if (Debugging)
        {
            Debug.Log("Firing Laser!");
        }

        Instantiate(BulletPrefab, BulletSpawnPoint.position ,transform.rotation );
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRunner : MonoBehaviour {

    public GameObject[] TilePrefabs;
    public float Speed = 5;
    public float DistanceToTravel = 20;
    public Vector3 Direction;

    private Vector3 directionNormalized;
    private float timeAlive;

	// Use this for initialization
	void Start () {
        directionNormalized = Direction.normalized;
        timeAlive = DistanceToTravel / Speed;
        Destroy(this.gameObject, timeAlive);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += directionNormalized * Speed * Time.deltaTime;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRunner : MonoBehaviour {

    public float Speed = 5;
    public Vector3 Direction;

    private Vector3 directionNormalized;

	// Use this for initialization
	void Start () {
        directionNormalized = Direction.normalized;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += directionNormalized * Speed * Time.deltaTime;
	}

}

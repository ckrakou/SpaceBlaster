using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TileRunner : MonoBehaviour {

    public Vector3 Direction;
    public float Speed = 5;
    public float RotationInterval = 3;

    private Vector3 directionNormalized;
    private float nextRotationTimestamp;


    // Use this for initialization
    void Start () {
        directionNormalized = Direction.normalized;
    }

    // Update is called once per frame
    void Update() {
        transform.position += directionNormalized * Speed * Time.deltaTime;
    }

   
}

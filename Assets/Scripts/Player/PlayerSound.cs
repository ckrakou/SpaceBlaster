using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {

    public AudioClip ShootSound;
    public AudioClip DeathSound;

    private AudioSource source;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void Explode()
    {
        source.clip = DeathSound;
        source.Play();
    }

    internal void Shoot()
    {
        source.clip = ShootSound;
        source.Play();
    }
}

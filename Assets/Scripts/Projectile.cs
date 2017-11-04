using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float Velocity = 20f;
    public float TimeAlive = 2f;


	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, TimeAlive);
	}
	
	// Update is called once per frame
	void Update () {
            transform.position += transform.right * Velocity * Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float Velocity = 20f;
    public float TimeAlive = 2f;
    public Vector3 Direction = Vector3.right;


    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, TimeAlive);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction * Velocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Fence"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            GameObject.Find("GameManager").GetComponent<ScoreKeeper>().ShotFence();
        }
        else if (other.gameObject.tag.Equals("Blocker"))
        {
            Destroy(this.gameObject);
        }
    }


}

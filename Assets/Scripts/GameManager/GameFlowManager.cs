using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    private List<Component> toDeactivate;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndGame()
    {
        foreach (var obstacle in GameObject.FindGameObjectsWithTag("Section"))
        {
            obstacle.GetComponent<TileRunner>().Speed = 0;
        }
        GameObject.Find("Road").GetComponent<TileSpawner>().enabled = false;
        GameObject.Find("Player").GetComponent<PlayerControl>().enabled = false;
    }
}

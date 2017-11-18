using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    public bool Debugging;

    private bool hasEnded;
    private Scene currentScene;

    // Use this for initialization
    void Start()
    {

        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasEnded)
        {
            if (Input.GetAxis("Shoot") > 0)
            {
                if (Debugging)
                {
                    Debug.Log("GameFlowManager: Restarting");
                }
                Reset();
            }
        }
    }

    private void Reset()
    {
        foreach (var obstacle in GameObject.FindGameObjectsWithTag("Section"))
        {
            Destroy(obstacle);
        }
        this.gameObject.GetComponent<TileSpawner>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerControl>().enabled = true;
        GetComponent<ScoreKeeper>().Reset();
        
    }

    public void EndGame()
    {
        if (Debugging)
        {
            Debug.Log("GameFlowManager: Ending Game");
        }
        foreach (var obstacle in GameObject.FindGameObjectsWithTag("Section"))
        {
            obstacle.GetComponent<TileRunner>().Speed = 0;
        }
        this.gameObject.GetComponent<TileSpawner>().enabled = false;
        GameObject.Find("Player").GetComponent<PlayerControl>().enabled = false;
        hasEnded = true;
    }
}

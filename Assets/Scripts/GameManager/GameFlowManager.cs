using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    public bool Debugging;

    private bool hasEnded;
    private GameObject player;
    private float restartTimestamp;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (hasEnded)
        {
            if (Time.time > restartTimestamp && Input.GetAxis("Shoot") > 0)
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
        player.GetComponentInChildren<PlayerJuice>().FadeIn();
        GetComponent<ScoreKeeper>().Reset();
        player.GetComponent<PlayerControl>().enabled = true;
        hasEnded = false;
    }

    public void EndGame()
    {
        if (Debugging)
        {
            Debug.Log("GameFlowManager: Ending Game");
        }

        this.gameObject.GetComponent<TileSpawner>().enabled = false;
        player.GetComponent<PlayerControl>().enabled = false;

        foreach (var obstacle in GameObject.FindGameObjectsWithTag("Section"))
        {
            obstacle.GetComponent<TileRunner>().Speed = 0;
        }

        player.GetComponentInChildren<PlayerSound>().Explode();
        player.GetComponentInChildren<PlayerJuice>().FadeOut();

        hasEnded = true;
        restartTimestamp = Time.time + player.GetComponentInChildren<PlayerJuice>().DestroyTime;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    public bool Debugging;
    public float MaxWaitTime = 5f;

    private GameObject player;
    private DataCollector collector;
    private float restartTimestamp;

    private GameState currentState;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        collector = GetComponentInChildren<DataCollector>();
        UpdateState(GameState.SPLASH);
    }

    private void UpdateState(GameState state)
    {
        currentState = state;
        switch (currentState)
        {
            case GameState.SPLASH:
                ShowSplash();
                break;
            case GameState.PLAYING:
                Reset();
                break;
            case GameState.DIED:
                TearDown();
                break;
            case GameState.WAITING:
                break;
            default:
                break;
        }

        if (Debugging)
        {
            Debug.Log("GameFlowManager: State changed to " + state);
        }
    }

    private void ShowSplash()
    {
        GameObject.Find("SplashScreen").GetComponent<SplashScreenJuice>().FadeIn();
        this.gameObject.GetComponent<TileSpawner>().enabled = false;
        foreach (var obstacle in GameObject.FindGameObjectsWithTag("Section"))
        {
            Destroy(obstacle);
        }
        player.GetComponent<PlayerControl>().enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GameState.SPLASH:
                if (Input.GetAxis("Shoot") > 0)
                {
                    if (Debugging)
                    {
                        Debug.Log("GameFlowManager: Starting Game");
                    }
                    UpdateState(GameState.PLAYING);
                }
                break;
            case GameState.WAITING:
                if (Time.time > restartTimestamp && Input.GetAxis("Shoot") > 0)
                {
                    if (Debugging)
                    {
                        Debug.Log("GameFlowManager: Restarting Game");
                    }
                    UpdateState(GameState.PLAYING);
                }

                else if (Time.time > restartTimestamp + MaxWaitTime)
                {
                    if (Debugging)
                    {
                        Debug.Log("GameFlowManager: Resetting to splash screen");
                    }
                    UpdateState(GameState.SPLASH);
                }
                break;
            case GameState.DIED:
            case GameState.PLAYING:
            default:
                break;
        }

    }

    private void Reset()
    {
        GameObject.Find("SplashScreen").GetComponent<SplashScreenJuice>().FadeOut();
        collector.Begin();
        foreach (var obstacle in GameObject.FindGameObjectsWithTag("Section"))
        {
            Destroy(obstacle);
        }

        this.gameObject.GetComponent<TileSpawner>().enabled = true;
        player.GetComponentInChildren<PlayerJuice>().FadeIn();
        GetComponent<ScoreKeeper>().Reset();
        GetComponent<DifficultyManager>().ResetDifficulty();
        player.GetComponent<PlayerControl>().enabled = true;
    }

    public void EndGame()
    {
        collector.End();
        UpdateState(GameState.DIED);
    }

    private void TearDown()
    {

        foreach (var obstacle in GameObject.FindGameObjectsWithTag("Section"))
        {
            obstacle.GetComponent<TileRunner>().Speed = 0;
        }

        this.gameObject.GetComponent<TileSpawner>().enabled = false;
        player.GetComponent<PlayerControl>().enabled = false;

        player.GetComponentInChildren<PlayerSound>().Explode();
        player.GetComponentInChildren<PlayerJuice>().FadeOut();

        restartTimestamp = Time.time + player.GetComponentInChildren<PlayerJuice>().DestroyTime;

        UpdateState(GameState.WAITING);
    }

    private enum GameState
    {
        SPLASH,PLAYING,DIED,WAITING
    }
}

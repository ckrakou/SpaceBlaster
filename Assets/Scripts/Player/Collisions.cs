using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public bool Debugging = false;
    public GameObject GameManager;

    private ScoreKeeper scoreKeeper;
    private GameFlowManager gameFlowManager;

    // Use this for initialization
    void Start()
    {
        scoreKeeper = GameManager.GetComponent<ScoreKeeper>();
        gameFlowManager = GameManager.GetComponent<GameFlowManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (Debugging)
        {
            Debug.Log("Collision: OnTriggerEnter executed");
        }

        string tag = other.gameObject.tag;

        if (tag == "Section")
        {
            if (Debugging)
            {
                Debug.Log("Collisions: Passed through a Section");
            }

            scoreKeeper.PassedSection();
        }
        else if (tag == "Blocker")
        {
            if (Debugging)
            {
                Debug.Log("Collisions: Passed through a Blocker");
            }
            gameFlowManager.EndGame();
        }
        else if (tag == "Fence")
        {
            if (Debugging)
            {
                Debug.Log("Collisions: Passed through a Fence");
            }
            gameFlowManager.EndGame();

        }
    }
}

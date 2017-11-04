using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LaneController : MonoBehaviour
{

    public bool Debugging;
    public GameObject LeftTile;
    public GameObject RightTile;
    public GameObject BlockerPrefab;
    public GameObject FencePrefab;
    public Transform[] ObstacleRows;

    private List<Transform> obstacleSpots;

    // Use this for initialization
    void Start()
    {
        obstacleSpots = new List<Transform>();
        foreach (var row in ObstacleRows)
        {
            foreach (var spot in row.GetComponentsInChildren<Transform>())
            {
                if (ObstacleRows.Contains(spot) == false)
                {
                    obstacleSpots.Add(spot);
                }
            }
        }
        if (Debugging)
            Debug.Log("LaneController: Added " + obstacleSpots.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

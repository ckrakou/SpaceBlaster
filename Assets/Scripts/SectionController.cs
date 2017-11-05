using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionController : MonoBehaviour {

    public bool Debugging;
    public GameObject BlockerPrefab;
    public GameObject FencePrefab;

    private void Awake()
    {
        if (Debugging)
        {
            foreach (var spawner in GetComponentsInChildren<ObstacleSpawner>())
            {
                spawner.Debugging = true;
                spawner.BlockerPrefab = BlockerPrefab;
                spawner.FencePrefab = FencePrefab;
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

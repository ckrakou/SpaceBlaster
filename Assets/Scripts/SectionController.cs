using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionController : MonoBehaviour {

    public bool Debugging;

    private void Awake()
    {
        if (Debugging)
        {
            foreach (var laneController in GetComponentsInChildren<LaneController>())
            {
                laneController.Debugging = true;
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

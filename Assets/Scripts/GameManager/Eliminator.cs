using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Eliminator : MonoBehaviour {

    public string[] TagsToDestroy;
    public DataCollector dataCollector;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (TagsToDestroy.Contains(other.tag))
        {
            Destroy(other.gameObject);
            if (other.tag.Equals("Section"))
            {
                dataCollector.SegmentCleared();
            }
        }
    }
}

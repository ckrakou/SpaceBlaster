using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickTest : MonoBehaviour
{
    public bool ZeroInput = false;
    public float ObservedMiddleValue;
    public float horizontalOffset;

    

    // Use this for initialization
    void Start()
    {
        if (ZeroInput)
        {
            horizontalOffset = Input.GetAxis("Horizontal");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(
         (Input.GetAxis("Horizontal") - horizontalOffset) + " ____ "
         );
        if (Input.GetAxis("Horizontal") - horizontalOffset == 0)
        {
            Debug.Log("Nothing");

        }
        else if (Input.GetAxis("Horizontal") - horizontalOffset < 0)
        {
            Debug.Log("Left");

        }
        else
        {
            Debug.Log("Right");
        }

        

    }
}

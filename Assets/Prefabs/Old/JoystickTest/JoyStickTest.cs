using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickTest : MonoBehaviour
{
    public bool ZeroInput = false;
    public float ObservedMiddleValue;
    public float horizontalOffset;
    public float verticalOffset;

    

    // Use this for initialization
    void Start()
    {
        if (ZeroInput)
        {
            verticalOffset = Input.GetAxis("Vertical");
            horizontalOffset = Input.GetAxis("Horizontal");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(
         (Input.GetAxis("Horizontal") - horizontalOffset) + " ____ " +
         (Input.GetAxis("Vertical") - verticalOffset)
         );

        if (Input.GetAxis("Horizontal") - horizontalOffset < ObservedMiddleValue)
        {
            Debug.Log("Left");

        }
        else
        {
            Debug.Log("Right");
        }

        if (Input.GetAxis("Vertical") - verticalOffset < ObservedMiddleValue)
        {
            Debug.Log("Down");

        }
        else
        {
            Debug.Log("Up");
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array : MonoBehaviour
{

    public int heartRowLength;
    public int heartRowNumber;

    // Use this for initialization
    void Start()
    {
        GenerateArray();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateArray()
    {
        /*
        for (int ix = 0; ix < heartRowLength; ix++)
        {
            for (int iy = 0; iy < heartRowNumber; iy++)
            {
                print("X = " + ix + ", Y = " + iy);
            }
        }
        */

        for (int iy = 0; iy < heartRowNumber; iy++)
        {
            for (int ix = 0; ix < heartRowLength; ix++)
            {
                print("X = " + ix + ", Y = " + iy);
                // Instantiate heart in grid arrangement based on ix and iy
                // Assign heart to next grid slot
                // Determine heart image
            }
        }
    }
}

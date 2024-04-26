using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject rearAxle;
    public GameObject[] frontWheels = new GameObject[2];
    public GameObject frontLeft;
    public float spinSpeed;
    public float turnSpeed;
    public bool turnDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // WARNING!!!
                  // THIS CODE CRASHES UNITY. I DON'T KNOW WHY.
                  // ALSO, IF YOU RUN IT ANYWAY AND IT DOES CRASH,
                  // YOU'LL HAVE TO RESTART YOUR MACHINE BECAUSE
                  // YOU CAN'T OPEN TASK MANAGER ON THESE COMPUTERS.
                  
                  // THIS IS LITERALLY 1984
    {
        rearAxle.transform.Rotate(spinSpeed, 0, 0);
        switch (turnDirection)
        {
            case true: 
                while (frontLeft.transform.rotation.y < 55)
                {
                    foreach (GameObject wheel in frontWheels)
                    {
                        wheel.transform.Rotate(0, turnSpeed, 0);
                    }
                }
                turnDirection = false;
                break;
            case false:
                while (frontLeft.transform.rotation.y > -55)
                {
                    foreach (GameObject wheel in frontWheels)
                    {
                        wheel.transform.Rotate(0, -turnSpeed, 0);
                    }
                }
                turnDirection = true;
                break;
        }
    }
}

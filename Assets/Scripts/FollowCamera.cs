using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject car;
    public GameObject cam;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (car != null)
        {
            cam.transform.position = car.transform.position + new Vector3(0, 3, 0);
            Quaternion left = Quaternion.Euler(car.transform.rotation.x, car.transform.rotation.y - 45, car.transform.rotation.z);
            Quaternion right = Quaternion.Euler(car.transform.rotation.x, car.transform.rotation.y + 45, car.transform.rotation.z);
            // if (Input.GetAxis("Horizontal") == 0)
            // {
            cam.transform.rotation = car.transform.rotation;
            // }
            // else if (Input.GetAxis("Horizontal") > 0)
            // {
            //     cam.transform.rotation = right;
            // }
            // else if (Input.GetAxis("Horizontal") < 0)
            // {
            //     cam.transform.rotation = left;
            // }
        }

    }
}

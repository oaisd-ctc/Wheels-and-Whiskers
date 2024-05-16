using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarrierSlow : MonoBehaviour
{
    public Rigidbody rb;
    public float slowRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided!");
        float slow = slowRate * Time.deltaTime;
        // Vector3 sloow = new Vector3(slow, slow, slow); 
        other.gameObject.GetComponent<Rigidbody>().velocity /= slow;
    }
}

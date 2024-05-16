using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLine : MonoBehaviour
{
    public GameObject timer;
    public Timer script;
    // Start is called before the first frame update
    void Start()
    {
        script = timer.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        script.ResetTime();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Drive : MonoBehaviour
{
    // please, look away... i'm ashamed...
    public Rigidbody rb;
    public BoxCollider bx;
    public bool isSliding = false;
    public float turnInput;
    public float throttleBrakeInput;
    public float turnSpeed;
    public float enginePower;
    public bool isMoving = false;
    public GameObject rearAxle;
    public Vector3 facing;
    public Vector3 velocity;
    public float spinRate;
    public int rightOrLeft;
    public float gripRate;
    public float brakePower;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
    // i should know that by know, unity.
    void Update()
    {
        //  is the car moving?
        if(velocity != Vector3.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        // calculate the direction the car is facing and the direction
        // it's moving so i can compare them.
        facing = rb.rotation * Vector3.forward;
        velocity = rb.velocity;
        float angleDifference = Vector3.SignedAngle(facing, velocity, Vector3.up);
        // determine if the car is sliding.
        if(angleDifference > 2.5 || angleDifference < -2.5)
        {
            isSliding = true;
        }
        // if the car is sliding, which way is it sliding?
        if(isSliding)
        {
            if(angleDifference > 2.5)
            {
                rightOrLeft = 1;
            }
            else if(angleDifference < -2.5)
            {
                rightOrLeft = -1;
            }
            else
            {
                rightOrLeft = 0;
            }
        }
        // take inputs.
        turnInput = Input.GetAxis("Horizontal");
        throttleBrakeInput = Input.GetAxis("Vertical");
        // remember to actually call the functions.
        Turn(turnInput);
        Accelerate(throttleBrakeInput);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Brake());
        }
    }
    
    public void Turn(float input)
    {
        // turn.
        transform.Rotate(0, input * turnSpeed * Time.deltaTime, 0);
        rb.AddRelativeForce(Vector3.right * Time.deltaTime * input * (turnSpeed * gripRate) * -rightOrLeft);
    }

    public void Accelerate(float input)
    {
        // make the rotate faster over time,* so the player has to
        // be careful with the throttle when sliding. intended
        // to make it so the player will apply more throttle in 
        // order to keep drifting, and less throttle to keep
        // from spinning out.
        //
        // *when drifing
        float spin = Mathf.Pow(spinRate, Time.deltaTime);
        if(true)
        {
            //drive how you'd expect under normal conditions.
            rb.AddRelativeForce(Vector3.forward * enginePower * Time.deltaTime * input); 
        }
        // i may never add this funtionality :(
        else if(isSliding)
        {
            transform.Translate(velocity * (enginePower / 2) * Time.deltaTime);
            transform.Rotate(0, spin * rightOrLeft, 0);
        }
    }
    public IEnumerator Brake()
    {
        while (Input.GetKey(KeyCode.Space))
        {
            if (rb.velocity.magnitude > 0)
            {
                rb.velocity *= brakePower;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}

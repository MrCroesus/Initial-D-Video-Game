using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerControllerScript : MonoBehaviour
{
    //Car movement stats
    private float acceleration = 22.1f;
    public float topSpeed = 55.4f;
    private float brakeForce = 12.7f;

    //Car turning stats
    private float turnSpeed = 86.0f;

    //Number of gears the car has
    public const int numGears = 5;

    //Car acceleration at different gears
    private float[] accelerations;

    //Car gear speeds
    public float[] gearSpeeds;

    //Car speed
    public float speed;

    //Minimum speed before the car can turn
    private float minSpeedBeforeTurning = 1.3f;

    //Car current gear
    public int currentGear = 1;

    //Is the car on the ground
    private int colliderCount;

    //Input axes
    private float horizontalInput;
    private float verticalInput;

    //Rigidbody variable
    private Rigidbody rb;

    //Center of mass
    private Vector3 centerOfMass = new Vector3(0, -1.0f, 0);

    //Front wheels
    private GameObject wheelFL;
    private GameObject wheelFR;

    //Rims
    private GameObject rimFL;
    private GameObject rimFR;
    private GameObject rimRL;
    private GameObject rimRR;

    // Multiplayer
    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize accelerations, gear speeds, and the current gear
        accelerations = new float[numGears] { 10.2f, 11.9f, 13.8f, 16f, 18.6f };
        gearSpeeds = new float[numGears + 1] { 0.0f, 4.5f, 6.7f, 15.6f, 20.1f, 55.4f };
        currentGear = 1;

        //Initialize rigidbody variable and center of mass
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;

        //Initialize front wheels
        wheelFL = GameObject.Find("TireFL");
        wheelFR = GameObject.Find("TireFR");

        //Initialize rims
        rimFL = GameObject.Find("RimFL");
        rimFR = GameObject.Find("RimFR");
        rimRL = GameObject.Find("RimRL");
        rimRR = GameObject.Find("RimRR");

        // Multiplayer
        view = GetComponent<PhotonView>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        colliderCount += 1;
    }

    private void OnCollisionExit(Collision collision)
    {
        colliderCount -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            //Get input from axes
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            //Get speed
            speed = rb.velocity.magnitude;

            //Gear shift up
            if (Input.GetKeyDown(KeyCode.UpArrow) && currentGear < numGears)
            {
                currentGear += 1;
            }
            //Gear shift down
            else if (Input.GetKeyDown(KeyCode.DownArrow) && currentGear > 1)
            {
                currentGear -= 1;
            }

            //The car can only be controlled if it is on the ground
            if (colliderCount > 0)
            {
                //Get acceleration based on current gear if speed is within the gear's speed range
                if (speed >= gearSpeeds[currentGear - 1] * 0.9 && speed <= gearSpeeds[currentGear] * 1.1)
                {
                    acceleration = accelerations[currentGear - 1];
                }
                //Set acceleration to first gear acceleration otherwise
                else
                {
                    acceleration = accelerations[0];
                }

                //Accelerate
                if (verticalInput == 1)
                {
                    rb.AddForce(transform.forward * acceleration * Time.deltaTime, ForceMode.Impulse);
                }
                //Brake
                else if (verticalInput == -1)
                {
                    rb.AddForce(transform.forward * -brakeForce * Time.deltaTime, ForceMode.Impulse);
                }

                //Turn the car and wheels if the car is going fast enough
                if (speed > minSpeedBeforeTurning)
                {
                    transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput * verticalInput);
                    wheelFL.transform.localRotation = Quaternion.Euler(0, turnSpeed / 2 * horizontalInput, 90);
                    wheelFR.transform.localRotation = Quaternion.Euler(0, turnSpeed / 2 * horizontalInput, -90);
                }
            }

            //Rotate the wheels
            rimFL.transform.Rotate(Vector3.back, speed);
            rimFR.transform.Rotate(Vector3.back, speed);
            rimRL.transform.Rotate(Vector3.back, speed);
            rimRR.transform.Rotate(Vector3.back, speed);
        }
    }
}
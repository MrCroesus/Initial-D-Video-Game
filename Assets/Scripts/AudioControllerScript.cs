using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerScript : MonoBehaviour
{
    //Car player controller script
    private PlayerControllerScript carScript;

    //Engine audio source
    private AudioSource engine;

    //Drift audio source
    private AudioSource drift;

    //Input axes
    private float horizontalInput;
    private float verticalInput;

    //Previous current gear to check for gear shifts
    private int previousCurrentGear = 1;

    //Drift sound volume
    private float driftVolume;

    //Minimum speed before the car can drift
    private float minSpeedBeforeDrifting = 13.4f;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize car game object
        carScript = GameObject.Find("Car(Clone)").GetComponent<PlayerControllerScript>();

        //Initialize engine and drift audio sources
        engine = GameObject.Find("Engine").GetComponent<AudioSource>();
        drift = GameObject.Find("Drift").GetComponent<AudioSource>();

        //Start playing engine sounds
        engine.Play();

        //Start playing drift sounds at zero volume
        drift.volume = 0;
        drift.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //Get input from axes
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Increase the engine pitch
        engine.pitch = System.Math.Abs(verticalInput * carScript.speed / 30) + 1.1f;

        //Turn off engine sounds when there is a gear shift
        if (carScript.currentGear != previousCurrentGear)
        {
            engine.volume = 0;
            Invoke("resetEngineVolume", 0.1f);
            previousCurrentGear = carScript.currentGear;
        }

        //Calculate drift volume if the car is going fast enough
        if (carScript.speed > minSpeedBeforeDrifting)
        {
            driftVolume = horizontalInput * carScript.speed / 100;
        }
        else
        {
            driftVolume = 0;
        }

        //Set the drift volume
        drift.volume = System.Math.Abs(driftVolume);
    }

    //Set engine volume to 1
    private void resetEngineVolume()
    {
        engine.volume = 1;
    }
}

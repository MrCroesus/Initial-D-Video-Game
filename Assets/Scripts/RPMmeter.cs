using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPMmeter : MonoBehaviour
{
    //Angle constraints
    private int minAngle = 90;
    private int maxAngle = -90;

    //Car player controller script
    private PlayerControllerScript carScript;

    //RPM
    private float RPM;

    //RPM to angle conversion factor
    private float k;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize car game object
        carScript = GameObject.Find("Car").GetComponent<PlayerControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate RPM
        RPM = (carScript.speed)
            / (carScript.gearSpeeds[carScript.currentGear]);

        //Calculate conversion factor
        k = maxAngle - minAngle;

        //Rotate the RPM meter needle
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Max(Mathf.Min(minAngle, k * RPM + minAngle), maxAngle));
    }
}
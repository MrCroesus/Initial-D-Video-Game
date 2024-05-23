using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    //Angle constraints
    private int minAngle = 110;
    private int maxAngle = -100;

    //Car player controller script
    private PlayerControllerScript carScript;

    //Car top speed
    private float carTopSpeed;

    //Speed to angle conversion factor
    private float k;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Initialize car game object
        carScript = GameObject.Find("Car(Clone)").GetComponent<PlayerControllerScript>();

        //Get car top speed
        carTopSpeed = carScript.topSpeed;

        //Calculate conversion factor
        k = (maxAngle - minAngle) / carTopSpeed;

        //Rotate the speedometer needle
        transform.rotation = Quaternion.Euler(0, 0, k * carScript.speed + minAngle);
    }
}

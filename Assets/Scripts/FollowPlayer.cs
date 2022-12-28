using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //Car object
    private GameObject car;

    //How far behind the car the camera is by default
    private float horizontalOffset = -8.0f;
    private float verticalOffset = 1.1f;

    //How much the camera's position changes from the car's speed
    private float speedOffset;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize car game object
        car = GameObject.Find("Car");
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate camera offset due to speed
        speedOffset = -car.GetComponent<PlayerControllerScript>().speed / 30;

        //Translate the camera
        transform.position = car.transform.position + car.transform.forward * (horizontalOffset + speedOffset)
            + car.transform.up * verticalOffset;
    }
}

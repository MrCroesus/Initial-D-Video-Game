using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearLabel : MonoBehaviour
{
    //Car player controller script
    private PlayerControllerScript carScript;

    //Gear text box
    private Text gearText;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize car game object
        carScript = GameObject.Find("Car").GetComponent<PlayerControllerScript>();

        //Initialize gear text box
        gearText = GameObject.Find("Gear").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update the gear label
        gearText.text = carScript.currentGear.ToString();
    }
}

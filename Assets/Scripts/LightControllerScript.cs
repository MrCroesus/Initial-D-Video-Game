using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControllerScript : MonoBehaviour
{
    //Flip lights
    public Renderer flipLightL;
    public Renderer flipLightR;

    //Flip light materials
    public Material flipLightOn;
    public Material flipLightOff;

    //Flip lights on
    private bool flipLightsOn = false;

    //Fog lights
    public Renderer fogLightL;
    public Renderer fogLightR;

    //Fog light materials
    public Material fogLightOn;
    public Material fogLightOff;

    //Fog lights on
    private bool fogLightsOn = false;

    //Rear lights
    public Renderer rearLightL;
    public Renderer rearLightR;

    //Rear light materials
    public Material rearLightLOn;
    public Material rearLightLOff;
    public Material rearLightROn;
    public Material rearLightROff;

    //Side lights
    public Renderer sideLightL1;
    public Renderer sideLightL2;
    public Renderer sideLightR1;
    public Renderer sideLightR2;

    //Rear light materials
    public Material sideLightL1On;
    public Material sideLightL1Off;
    public Material sideLightL2On;
    public Material sideLightL2Off;
    public Material sideLightR1On;
    public Material sideLightR1Off;
    public Material sideLightR2On;
    public Material sideLightR2Off;

    //Fog lights on
    private bool sideLightsOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Flip lights
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Turn flip lights off
            if (flipLightsOn)
            {
                flipLightL.material = flipLightOff;
                flipLightR.material = flipLightOff;
                flipLightsOn = false;
            }
            //Turn flip lights on
            else
            {
                flipLightL.material = flipLightOn;
                flipLightR.material = flipLightOn;
                flipLightsOn = true;
            }
        }

        //Fog lights
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Turn fog lights off
            if (fogLightsOn)
            {
                fogLightL.material = fogLightOff;
                fogLightR.material = fogLightOff;
                fogLightsOn = false;
            }
            //Turn fog lights on
            else
            {
                fogLightL.material = fogLightOn;
                fogLightR.material = fogLightOn;
                fogLightsOn = true;
            }
        }

        //Turn rear lights on
        if (Input.GetKey(KeyCode.S))
        {
            rearLightL.material = rearLightLOn;
            rearLightR.material = rearLightROn;
        }
        //Turn rear lights off
        else
        {
            rearLightL.material = rearLightLOff;
            rearLightR.material = rearLightROff;
        }

        //Side lights
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Turn fog lights off
            if (sideLightsOn)
            {
                sideLightL1.material = sideLightL1Off;
                sideLightL2.material = sideLightL2Off;
                sideLightR1.material = sideLightR1Off;
                sideLightR2.material = sideLightR2Off;
                sideLightsOn = false;
            }
            //Turn fog lights on
            else
            {
                sideLightL1.material = sideLightL1On;
                sideLightL2.material = sideLightL2On;
                sideLightR1.material = sideLightR1On;
                sideLightR2.material = sideLightR2On;
                sideLightsOn = true;
            }
        }
    }
}

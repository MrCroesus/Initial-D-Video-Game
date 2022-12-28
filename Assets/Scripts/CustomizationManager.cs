using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationScript : MonoBehaviour
{
    //Paint color material
    public Material paint;

    //License plate input text object
    private GameObject licensePlateInputText;

    //License plate input field
    private InputField licensePlateInput;

    //License plate text box
    private Text licensePlateText;

    //Front license plate text box
    public TextMesh frontPlateText;

    //Rear license plate text box
    public TextMesh rearPlateText;


    // Start is called before the first frame update
    void Start()
    {
        //Initialize license plate input text object, input field, and text box
        licensePlateInputText = GameObject.Find("LicensePlate");
        licensePlateInput = licensePlateInputText.GetComponent<InputField>();
        licensePlateText = licensePlateInputText.GetComponentInChildren<Text>();

        //Limit license plates to 7 characters
        licensePlateInput.characterLimit = 7;
    }

    // Update is called once per frame
    void Update()
    {
        //Set the license plate texts
        frontPlateText.text = licensePlateText.text;
        rearPlateText.text = licensePlateText.text;
    }

    public void changeColor(string button) {
        switch (button)
        {
            case "Red":
                paint.color = new Color(192 / 256f, 0, 0);
                break;
            case "Yellow":
                paint.color = new Color(229 / 256f, 208 / 256f, 69 / 256f);
                break;
            case "Green":
                paint.color = new Color(92 / 256f, 148 / 256f, 103 / 256f);
                break;
            case "Blue":
                paint.color = new Color(3 / 256f, 24 / 256f, 117 / 256f);
                break;
            case "Wine":
                paint.color = new Color(117 / 256f, 27 / 256f, 48 / 256f);
                break;
            case "White":
                paint.color = new Color(1, 1, 1);
                break;
            case "Black":
                paint.color = new Color(0, 0, 0);
                break;
        }
    }
}

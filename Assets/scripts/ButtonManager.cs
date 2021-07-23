using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    int t;
    //instance of a button - prefab
    //create multiple instances
    //arrange them

    [SerializeField] private Text btnText;
    // [SerializeField] private Color btnColor;
    // [SerializeField]
    // private Color currentColor;
    [SerializeField] private Button[] buttons;
    
    public GameObject canvas;
    public GameObject button;

    void Start () 
    {
        GameObject newButton = Instantiate(button) as GameObject;
        // newButton.transform.SetParent(newCanvas.transform, false);
        newButton.transform.SetParent(canvas.transform);
        // newButton.transform.SetParent(canvas.transform);
        // newButton.transform.SetParent(canvas.transform);
        // Color btnColor = GetComponent<Button> ().Color;
        // btnColor.normalColor = Color.red;
        // GetComponent<Button> ().btnColor = btnColor;
    }

    // int color;
    // void ColorChange(int theColor)
    // {
    //     //changes the color of the pressed buttons
    // }

    // void DetectColor()
    // {
    //     //detects the color of the button that was pressed
    // }

    // void SetColor()
    // {
    //     //make the buttons flash various colors
    // }
}

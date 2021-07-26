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

    // [SerializeField] private Text btnText;
    // [SerializeField] private Color btnColor;
    [SerializeField] private int MAX_BTNS = 6;
    // private Color currentColor;
    // [SerializeField] private Button[] buttons;
    
    
    public GameObject canvas;
    public GameObject buttonPrefab;
    // button[] btnArray = new button[9];
    // List<button> btnArray = new ArrayList<button>();

    void Start () 
    {
        
        // GameObject newButton2 = Instantiate(button) as GameObject;
        // newButton.transform.SetParent(newCanvas.transform, false);
        
        // newButton2.transform.SetParent(canvas.transform);
        for (int i = 0; i < MAX_BTNS; i++) 
        {
            var buttonObj = Instantiate(buttonPrefab);
            var button = buttonObj.GetComponent<Button>();
            var image = buttonObj.GetComponent<Image>();
            image.color = Color.red;
            buttonObj.transform.SetParent(canvas.transform);
            int buttonIndex = i;
            buttonObj.name = buttonIndex.ToString();
            button.onClick.AddListener(() => onButtonClicked(button, buttonIndex));
        }

        // Color btnColor = GetComponent<Button> ().Color;
        // btnColor.normalColor = Color.red;
        // GetComponent<Button> ().btnColor = btnColor;
    }

    void onButtonClicked(Button btn, int index) {
        Debug.Log("clicked: " + btn.name);

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

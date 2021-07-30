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

//     string[] names = new string[] { "name1", "name2", "name3" };
// Random rnd = new Random();
// int index = rnd.Next(names.Length);
// Console.WriteLine($"Name: {names[index]}");

    //{green, pink, white, blue, yellow, purple} RGB
    // Color[] colors = { new Color(0,1,0,1), new Color(1,0,0,1), new Color(1,1,1,1), new Color(0,0,1,1),  new Color(1,1,0,1), new Color(0, 0, 0, 1)};
    // Random rndColor = new Random();
    void Start () 
    {
        
        // GameObject newButton2 = Instantiate(button) as GameObject;
        // newButton.transform.SetParent(newCanvas.transform, false);
        // newButton2.transform.SetParent(canvas.transform);

        Color greenClr = new Color(0.349f, 0.126f, 0, 0.011f);
        Color pinkClr = new Color(0.349f, 0.126f, 0, 0.011f);
        Color whiteClr = new Color(1,1,1,1);
        Color blueClr = new Color(0.384f, 0.085f, 0, 0.031f);
        Color yellowClr = new Color(0, 0.052f, 0.204f, 0.019f);
        Color purpleClr = new Color(0.264f, 0.243f, 0, 0.050f);
//new Color(0, 0.052f, 0.204f, 0.019f), new Color(0.264f, 0.243f, 0, 0.050f)

        for (int i = 0; i < MAX_BTNS; i++) 
        {
            var buttonObj = Instantiate(buttonPrefab);
            var button = buttonObj.GetComponent<Button>();
            var image = buttonObj.GetComponent<Image>();
            Color[] colors = {greenClr, pinkClr, whiteClr, blueClr,  yellowClr, purpleClr};
            var randomIndex = Random.Range(0, colors.Length);
            image.color = colors[randomIndex];
            buttonObj.transform.SetParent(canvas.transform);
            int buttonIndex = i;
            buttonObj.name = buttonIndex.ToString();
            // buttonObj.
            button.onClick.AddListener(() => onButtonClicked(button, buttonIndex, randomIndex));
        }

        // Color btnColor = GetComponent<Button> ().Color;
        // btnColor.normalColor = Color.red;
        // GetComponent<Button> ().btnColor = btnColor;
    }

    void onButtonClicked(Button btn, int index, int clrIndex) {
        Debug.Log("clicked: " + btn.name);
        Debug.Log("color number: " + clrIndex);
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

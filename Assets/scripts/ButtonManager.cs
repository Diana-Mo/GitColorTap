using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    
    // [SerializeField] private Text btnText;
    // [SerializeField] private Color btnColor;
    [SerializeField] private int MAX_BTNS;
    // [SerializeField] 
    private GameObject[] buttonObjects;
    
    
    public GameObject canvas;
    public GameObject buttonPrefab;
    // button[] btnArray = new button[9];
    // List<button> btnArray = new ArrayList<button>();
    //string[] names = new string[] { "name1", "name2", "name3" };

    //{green, pink, white, blue, yellow, purple} RGB
    int totalPoints = 0;
    int targetColorIndex = 0;
    


    void Start () 
    {

        // colors = {greenClr, pinkClr, whiteClr, blueClr,  yellowClr, purpleClr};
        targetColorIndex = Random.Range(0, 5);
        Debug.Log("target color: " + targetColorIndex);
        for (int i = 0; i < MAX_BTNS; i++) 
        {
            GameObject buttonObj = Instantiate(buttonPrefab);
            Button button = buttonObj.GetComponent<Button>();
            buttonObj.transform.SetParent(canvas.transform);
            // Image image = buttonObj.GetComponent<Image>();
            int randomClrIndex = Random.Range(0, GameManager.Instance.Colors.Length);
            // image.color = colors[randomClrIndex];
            int buttonIndex = i;
            var gameButton = buttonObj.GetComponent<GameButton>();
            gameButton.ColorIndex = randomClrIndex;
            buttonObj.name = buttonIndex.ToString();
            button.onClick.AddListener(() => OnButtonClicked(buttonObj));
            // totalPoints += onButtonClicked(button, buttonIndex, randomClrIndex, randomTargetIndex, totalPoints);
        }

        for (int i = 0; i < MAX_BTNS; i++)
        {
            // Color[] colors = {greenClr, pinkClr, whiteClr, blueClr,  yellowClr, purpleClr};
            // var randomClrIndex = Random.Range(0, colors.Length);
            // image.color = colors[randomClrIndex];
        }
    }

    void OnButtonClicked(GameObject btnObj) {
        // Debug.Log("clicked: " + btn.name);
        var gameButton = btnObj.GetComponent<GameButton>();
        
        int clrIndex = gameButton.ColorIndex;
        Debug.Log("color number: " + clrIndex);
        // Debug.Log("target color: " + targetIndex);
        if (clrIndex == targetColorIndex)
        {
            totalPoints += 5;
            Debug.Log("score: " + totalPoints);
            for (int i = 0; i < MAX_BTNS; i++) 
            {
            // AssignColors(image, colors, clrIndex);
                // AssignColors(image, colors, clrIndex);
            }
        }
        // return points;
    }

// void AssignColors(Image img, Color[] clrs, int rndClrIndex)
    void AssignColors(Image img, Color[] clrs, int rndClrIndex)
    {
        for (int i = 0; i < MAX_BTNS; i++)
        {
        img.color = clrs[rndClrIndex];
        }
    }
}

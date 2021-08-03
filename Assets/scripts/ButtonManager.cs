using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    // [SerializeField] private Text btnText;
    // [SerializeField] private Color btnColor;
    [SerializeField] private int MAX_BTNS;
    // [SerializeField] private Button[] buttons;
    
    
    public GameObject canvas;
    public GameObject buttonPrefab;
    // button[] btnArray = new button[9];
    // List<button> btnArray = new ArrayList<button>();
    //string[] names = new string[] { "name1", "name2", "name3" };

    //{green, pink, white, blue, yellow, purple} RGB
    int totalPoints = 0;
    Color greenClr = new Color(0.603f, 0.917f, 0.615f, 1);
    Color pinkClr = new Color(0.945f, 0.674f, 0.780f, 1); 
    Color whiteClr = new Color(1,1,1,1);
    Color blueClr = new Color(0.584f, 0.749f, 0.917f, 1);
    Color yellowClr = new Color(0.980f, 0.894f, 0.498f, 1);
    Color purpleClr = new Color(0.741f, 0.549f, 0.929f, 1);

    void Start () 
    {

        Color[] colors = {greenClr, pinkClr, whiteClr, blueClr,  yellowClr, purpleClr};
        int randomTargetIndex = Random.Range(0, 5);
        for (int i = 0; i < MAX_BTNS; i++) 
        {
            GameObject buttonObj = Instantiate(buttonPrefab);
            Button button = buttonObj.GetComponent<Button>();
            buttonObj.transform.SetParent(canvas.transform);
            Image image = buttonObj.GetComponent<Image>();
            int randomClrIndex = Random.Range(0, colors.Length);
            AssignColors(button, image, colors, randomClrIndex);
            int buttonIndex = i;
            buttonObj.name = buttonIndex.ToString();
            button.onClick.AddListener(() => OnButtonClicked(button, buttonIndex, randomClrIndex, randomTargetIndex, totalPoints));
            // totalPoints += onButtonClicked(button, buttonIndex, randomClrIndex, randomTargetIndex, totalPoints);
        }

        for (int i = 0; i < MAX_BTNS; i++)
        {
            // Color[] colors = {greenClr, pinkClr, whiteClr, blueClr,  yellowClr, purpleClr};
            // var randomClrIndex = Random.Range(0, colors.Length);
            // image.color = colors[randomClrIndex];
        }
    }

    void OnButtonClicked(Button btn, int index, int clrIndex, int targetIndex, int points) {
        Debug.Log("clicked: " + btn.name);
        Debug.Log("color number: " + clrIndex);
        Debug.Log("target color: " + targetIndex);
        if (clrIndex == targetIndex)
        {
            points += 5;
        }
        Debug.Log("score: " + points);
        // return points;
    }

    void AssignColors(Button btn, Image img, Color[] clrs, int rndClrIndex)
    {
        img.color = clrs[rndClrIndex];
    }
}

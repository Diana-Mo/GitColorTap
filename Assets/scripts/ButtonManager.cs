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
    
    [SerializeField] private Text currentColorLbl;
    [SerializeField] string[] colorNames;
    // [SerializeField] public Color[] Colors;
    public GameObject canvas;
    public GameObject buttonPrefab;
    // int targetColorIndex = -1;
    int targetColorIndex_ = -1;
    public int TargetColorIndex {
        get {
            return targetColorIndex_;
        }
        set {
            targetColorIndex_ = value;
            // todo: update 'targetColor' field
        }
    }
    // public List<int> btnColorsSet = new List<int>();

    // button[] btnArray = new button[9];
    // List<button> btnArray = new ArrayList<button>();
    //string[] names = new string[] { "name1", "name2", "name3" };

    //{green, pink, white, blue, yellow, purple} RGB
    // int totalPoints = 0;
    // int targetColorIndex = -1;
    //make this a game manager variable and reference here from there through instance
    // public int TargetColorIndex {
    //     get {
    //         return targetColorIndex;
    //     }
    //     set {
    //         targetColorIndex = value;
    //     }
    // }

    void Start () 
    {

        // colors = {greenClr, pinkClr, whiteClr, blueClr,  yellowClr, purpleClr};
        for (int i = 0; i < MAX_BTNS; i++) 
        {
            GameObject buttonObj = Instantiate(buttonPrefab);
            // buttonObj
            Button button = buttonObj.GetComponent<Button>();
            buttonObj.transform.SetParent(canvas.transform);
            // Image image = buttonObj.GetComponent<Image>();
            int randomClrIndex = Random.Range(0, GameManager.Instance.Colors.Length);
            // GameManager.Instance.Colors.Length
            // image.color = colors[randomClrIndex];
            int buttonIndex = i;
            var gameButton1 = buttonObj.GetComponent<GameButton>();
            // Debug.Log("randm color: " + randomClrIndex);
            gameButton1.ColorIndex = randomClrIndex;
            // btnColorsSet.Add(gameButton.ColorIndex);
    
            // Debug.Log("randm color: " + gameButton.ColorIndex);
            
            buttonObj.name = buttonIndex.ToString();
            button.onClick.AddListener(() => GameManager.Instance.OnButtonClicked(buttonObj));
            // totalPoints += onButtonClicked(button, buttonIndex, randomClrIndex, randomTargetIndex, totalPoints);
        }

// GetChildCount
        var buttonGo = canvas.transform.GetChild(Random.Range(0, MAX_BTNS));
        var gameButton = buttonGo.GetComponent<GameButton>();
        targetColorIndex_ = gameButton.ColorIndex;
        currentColorLbl.text = colorNames[targetColorIndex_];
        currentColorLbl.color = GameManager.Instance.Colors[targetColorIndex_];
        // Debug.Log("target color: " + targetColorIndex);

        // for (int i = 0; i < MAX_BTNS; i++)
        // {
            // Color[] colors = {greenClr, pinkClr, whiteClr, blueClr,  yellowClr, purpleClr};
            // var randomClrIndex = Random.Range(0, colors.Length);
            // image.color = colors[randomClrIndex];
        // }
    }

    

    // void OnButtonClicked(GameObject btnObj) {
        // Debug.Log("clicked: " + btnObj.name);
        // var gameButton = btnObj.GetComponent<GameButton>();
        
        // int clrIndex = gameButton.ColorIndex;
        // Debug.Log("color number: " + clrIndex);
        // Debug.Log("target color: " + targetIndex);
        // if (clrIndex == GameManager.Instance.targetColorIndex)
        // {
        //     totalPoints += 5;
        //     Debug.Log("score: " + totalPoints);
        //     for (int i = 0; i < MAX_BTNS; i++) 
        //     {
        //     AssignColors(image, colors, clrIndex);
        //         AssignColors(image, colors, clrIndex);
        //     }
        // }
    // }

// void AssignColors(Image img, Color[] clrs, int rndClrIndex)
    // void AssignColors(Image img, Color[] clrs, int rndClrIndex)
    // {
    //     for (int i = 0; i < MAX_BTNS; i++)
    //     {
    //     img.color = clrs[rndClrIndex];
    //     }
    // }
}

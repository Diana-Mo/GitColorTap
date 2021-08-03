using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private static ButtonManager instance;

    public static ButtonManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<ButtonManager>();
            }

            return instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
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
    Color greenClr = new Color(0.603f, 0.917f, 0.615f, 1);
    Color pinkClr = new Color(0.945f, 0.674f, 0.780f, 1); 
    Color whiteClr = new Color(1,1,1,1);
    Color blueClr = new Color(0.584f, 0.749f, 0.917f, 1);
    Color yellowClr = new Color(0.980f, 0.894f, 0.498f, 1);
    Color purpleClr = new Color(0.741f, 0.549f, 0.929f, 1);
    [SerializeField] public Color[] Colors;


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
            int randomClrIndex = Random.Range(0, Colors.Length);
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

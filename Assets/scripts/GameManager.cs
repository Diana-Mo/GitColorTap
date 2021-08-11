using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// public enum gameStatus
// {
//     next, play, gameover, win
// }

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
            }

            return instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] public Color[] Colors;
    [SerializeField] private Text currentScoreLbl;
    [SerializeField] private Text currentTimeLbl;
    float timeStart = 10.0f;
    float currentTime = 0.0f;
    int targetColorIndex = -1;
    Color targetColor;
    int totalPoints = 0;
    public GameObject btnCanvas;
    public GameObject playScreen;
    int conseqBtns = 0;
    bool correctBtn = false;
    // [SerializeField]
    // private Text playBtnLbl;
    // [SerializeField]
    // private Button playBtn;
    // private Text currentRoundLbl;
    // private int round = 0;
    // private gameStatus currentState = gameStatus.play;

    // Start is called before the first frame update
    void Start()
    {
        currentTimeLbl.text = timeStart.ToString();
        currentTime = timeStart;

        // playBtn.gameObject.SetActive(false);
        // showMenu();
    }

    public void OnButtonClicked(GameObject btnObj)
    {
        var gameButton = btnObj.GetComponent<GameButton>();
        int clrIndex = gameButton.ColorIndex;
        var buttonManager = playScreen.GetComponent<ButtonManager>();
        if (clrIndex == buttonManager.TargetColorIndex)
        {
            correctBtn = true;
            totalPoints += 10;
            conseqBtns += 1;
            totalPoints += conseqBtns*(conseqBtns - 1);
            AssignColors();
            buttonManager.SetTargetColorLbl();
            currentTime += 5.00f;
        }
        else
        {
            correctBtn = false;
            conseqBtns = 0;
            totalPoints -= 5;
            if (totalPoints < 0)
                totalPoints = 0;
            currentTime += -5.00f;
        }
    }

    // Update is called once per frame 
    void Update()
    {
        UpdateScore(totalPoints);
        // timeStart -= Time.deltaTime;
        // currentTimeLbl.text = timeStart.ToString("0.0");
        if (currentTime >= 0.00f)
        {
        currentTime = currentTime - Time.deltaTime;
        // currentTime += correctBtn ? (5) : (-5); 
        }
        else
        {
            currentTime = 0;
        }
        currentTimeLbl.text = currentTime.ToString("0.0");
    }

    void AssignColors()
    {
        for (int i = 0; i < 16; i++) 
        {
            var currButton = btnCanvas.transform.GetChild(i);
            int randomClrIndex = Random.Range(0, Colors.Length);
            var gameButton1 = currButton.GetComponent<GameButton>();
            // Debug.Log("randm color: " + randomClrIndex);
            gameButton1.ColorIndex = randomClrIndex;
        }
    }
    void UpdateScore(int totPoints)
    {
        currentScoreLbl.text = totalPoints.ToString();
        // return currentColorLbl.text; (if method returns string)
    }

    // public void IsRoundOver()
    // {
    //     //totalEscapedLbl.text = "Escaped " + TotalEscaped + "/10";
    //     // if (/*num of correct tiles pressed) == total tiles for this round*/)
    //     // {
    //     //     //have the number of tiles to press increase depending on how far into the game the player is
    //     //     setCurrentGameState();
    //     //     showMenu();
    //     // }
    // }

    // public void setCurrentGameState()
    // {
    //     // if (/*time’s out and not enough buttons pressed*/)
    //     // {
    //     //     currentState = gameStatus.gameover;
    //     // }
    //     // else if (/*round is zero and zero keys are missed*/)
    //     // {
    //     //     currentState = gameStatus.play;
    //     // }
    // }

    // public void showMenu()
    // {
    //     switch (currentState)
    //     {
    //         case gameStatus.gameover:
    //             playBtnLbl.text = "Play Again";
    //             break;
    //         case gameStatus.play:
    //             playBtnLbl.text = "Play";
    //             break;
    //         case gameStatus.win:
    //             playBtnLbl.text = "Play";
    //             break;
    //     }

    //     playBtn.gameObject.SetActive(true);
    // }

    // public void playBtnPressed()
    // {
    //     //describes what happenes when the play button is pressed
    //     switch (currentState)
    //         //when the game state is set to play, the menu closes and the play screen pops up
    //     {
    //         default:
    //             //set the number of rounds to complete before the color changes
    //             //convert color int to color string and set the displayed color text to that string
    //             //make the goal color the chosen color
    //             break;
    //     }
    // }
}

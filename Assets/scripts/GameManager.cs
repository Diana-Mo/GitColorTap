using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum gameStatus
{
    next, play, gameover, win
}

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private Text currentScoreLbl;
    [SerializeField]
    private Text currentColorLbl;
    [SerializeField]
    private Text currentTimeLbl;
    [SerializeField]
    private Text playBtnLbl;
    [SerializeField]
    private Button playBtn;
    private Text currentRoundLbl;

    private int score = 0;
    private float time = 0.0f;
    private int round = 0;
    private gameStatus currentState = gameStatus.play;
    private int color = 0;
    private bool ReadyToPickColor = true;

    // Start is called before the first frame update
    void Start()
    {
        playBtn.gameObject.SetActive(false);
        showMenu();
    }
    //assign an int to a bunch of colors so that I could make the program to randomly pick an int and then the color that corresponds to the chosen int will be displayed.

    private List<Color> ColorList = new List<Color>();
    //copied this from one of my previous codes. Not sure of which type should the list be so for now I put color.. 
    //(probably int or string though unless I make a separate script for colors?)

    public void ChooseColor() //probably should use an IEnumerator
    {

    }

    public void IsRoundOver()
    {
        //totalEscapedLbl.text = "Escaped " + TotalEscaped + "/10";
        if (/*num of correct tiles pressed) == total tiles for this round*/)
        {
            //have the number of tiles to press increase depending on how far into the game the player is
            setCurrentGameState();
            showMenu();
        }
    }

    public void setCurrentGameState()
    {
        if (/*time’s out and not enough buttons pressed*/)
        {
            currentState = gameStatus.gameover;
        }
        else if (/*round is zero and zero keys are missed*/)
        {
            currentState = gameStatus.play;
        }
    }

    public void showMenu()
    {
        switch (currentState)
        {
            case gameStatus.gameover:
                playBtnLbl.text = "Play Again";
                break;
            case gameStatus.play:
                playBtnLbl.text = "Play";
                break;
            case gameStatus.win:
                playBtnLbl.text = "Play";
                break;
        }

        playBtn.gameObject.SetActive(true);
    }

    public void playBtnPressed()
    {
        switch (currentState)
        {
            default:
                //set the number of rounds to complete before the color changes
                //convert color int to color string and set the displayed color text to that string
                //make the goal color the chosen color
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // the change score function would be responsible for changing the score
    //
    void ChangeScore()
    {

    }

    void ChangeTimer()
    {

    }

    void ChangeScreens()
    {

    }

    void Round()
    {
        //updates timer and writing on screen each round as well as sets objectives
        //pick which color is the color for this round
        //counts number of buttons pressed and keeps track of timer

    }
}

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

    // Color greenClr = new Color(0.603f, 0.917f, 0.615f, 1);
    // Color pinkClr = new Color(0.945f, 0.674f, 0.780f, 1); 
    // Color whiteClr = new Color(1,1,1,1);
    // Color blueClr = new Color(0.584f, 0.749f, 0.917f, 1);
    // Color yellowClr = new Color(0.980f, 0.894f, 0.498f, 1);
    // Color purpleClr = new Color(0.741f, 0.549f, 0.929f, 1);
    [SerializeField] public Color[] Colors;

    [SerializeField]
    private Text currentScoreLbl;
    [SerializeField]
    private Text currentColorLbl;
    [SerializeField]
    private Text currentTimeLbl;
    // [SerializeField]
    // private Text playBtnLbl;
    // [SerializeField]
    // private Button playBtn;
    // private Text currentRoundLbl;

    // private int score = 0;
    // private float time = 0.0f;
    // private int round = 0;
    // private gameStatus currentState = gameStatus.play;
    // private int color = 0;
    // private bool ReadyToPickColor = true;

    // private List<Color> ColorList = new List<Color>();

    // Start is called before the first frame update
    void Start()
    {
        // var mc = new GameManager();
        //change the color text depending on the target index
        if (GameManager.TargetColorIndex == 0)
        {
            // Try the following lines instead.
        // var mc = new MyClass();
        // mc.i = 10;
        // mc.f();
        // int p = mc.Prop;
        }

        // playBtn.gameObject.SetActive(false);
        // showMenu();
    }


    // public void ChooseColor() //probably should use an IEnumerator
    // {

    // }

    // //should put this in Update instead ?
    // public float Score(int btnsPressed, int round, float time, int conseqBtns, int currColor)
    // {
    //     float currScore = 0.0f;
        
    //     /*
    //     if correct color
    //     {
    //         add 10 points to currScore
    //         currScore = conseqBtns*(conseqBtns - 1);
    //     }
    //     */
    //     return currScore;
    // }

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

    // // Update is called once per frame
    // void Update()
    // {
    //     //update time (how do i do that?)
    //     //have there be less and less time depending on the round 
    //     //take away several seconds for misclicks
    // }

    // // the change score function would be responsible for changing the score
    // //
    // void ChangeScore()
    // {

    // }

    // void ChangeTimer()
    // {

    // }

    // void ChangeScreens()
    // {

    // }

    // void Round()
    // {
    //     //updates timer and writing on screen each round as well as sets objectives
    //     //pick which color is the color for this round
    //     //counts number of buttons pressed and keeps track of timer

    // }
}

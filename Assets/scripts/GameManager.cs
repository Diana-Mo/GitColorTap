using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum gameStatus
{
    menu, play, gameover, nextround
}

public class GameManager : MonoBehaviour

// set game states, save/load highscore, manage time
// take care all things that happen on click of game buttons
// - score, noises, time, rounds, floating effect

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
    [SerializeField] private Text lastScoreLbl;
    [SerializeField] private Text highScoreLbl;
    [SerializeField] GameObject scoreChangePrefab;
    [SerializeField] RectTransform endPoint;
    // [SerializeField] Transform pointParent;
    [SerializeField] Color addPointsColor;

    [SerializeField] Color subtractPointsColor;
    [SerializeField] Color zeroPointsInvisible;
    int nowPoints = 0;
    int addedPoints = 0;
    float timeStart = 10.3f;
    float roundTimeStart = 0.0f;
    float currentTime = 0.0f;
    // int targetColorIndex = -1;
    // Color targetColor;
    int totalPoints = 0;
    public GameObject btnCanvas;
    [SerializeField] public GameObject playScreen;
    [SerializeField] public GameObject menuScreen;
    int conseqBtns = 0;
    bool correctBtn = false;
    // [SerializeField] private GameObject menuCanvas;
    [SerializeField] private Button playBtn;
    [SerializeField] private Text playBtnLbl;
    [SerializeField] private Text currentRoundLbl;
    int roundNum = 0;
    int correctBtnNumInRound = 0;
    int totalBtnNumInRound = 6;
    // private gameStatus currentState = gameStatus.menu;
    [SerializeField] public AudioClip sfxClick;

    [SerializeField] public AudioClip sfxColors;
    [SerializeField] public AudioClip sfxRightColor;
    [SerializeField] public AudioClip sfxGameOver;
    // [SerializeField] public AudioClip sfxBgMusic;

    private AudioSource audioSource;
    private gameStatus currentState = gameStatus.menu;
    // Start is called before the first frame update
    void Start()
    {
        currentState = gameStatus.menu;
        ShowMenu();
        playBtn.onClick.AddListener(() => PlayBtnClicked());
        audioSource = GetComponent<AudioSource>();
        // LoadPrefs();
        highScoreLbl.text = LoadedPrefs().ToString();
        // PlayerPrefs.GetString("highScore", "0");
        // audioSource.PlayOneShot(sfxBgMusic);
        // highScoreLbl.text = "0";
    }

    private void PlayBtnClicked()
    {
        audioSource.PlayOneShot(sfxClick);
        currentState = gameStatus.play;
        ShowMenu();
        StartTime();
        totalPoints = 0;
    }

    private void StartTime()
    {
        roundTimeStart = timeStart;
        currentTimeLbl.text = roundTimeStart.ToString();
        currentTime = roundTimeStart;
    }

    public void OnButtonClicked(GameObject btnObj)
    {
        audioSource.PlayOneShot(sfxColors);
        var gameButton = btnObj.GetComponent<GameButton>();
        int clrIndex = gameButton.ColorIndex;
        var buttonManager = playScreen.GetComponent<ButtonManager>();
        nowPoints = totalPoints;
        if (clrIndex == buttonManager.TargetColorIndex)
        {
            audioSource.PlayOneShot(sfxRightColor);   
            correctBtn = true;

            totalPoints += 10;
            conseqBtns += 1;
            totalPoints += conseqBtns*(conseqBtns - 1);

            AssignColors();
            buttonManager.SetTargetColorLbl();

            // currentTime += 1.0f;
            correctBtnNumInRound += 1;
            if (correctBtnNumInRound >= totalBtnNumInRound)
            {
                // currentTime += 1.0f;
                roundNum += 1;
                correctBtnNumInRound = 0;
                roundTimeStart -= 0.3f;
                currentTime = roundTimeStart;
                if (roundNum % 2 == 0)
                {
                    totalBtnNumInRound += 1;
                }
                // currentState = gameStatus.nextround;
            }
            currentRoundLbl.text = "ROUND " + roundNum.ToString() + ": " + correctBtnNumInRound.ToString() + "/" + totalBtnNumInRound.ToString();

        } 
        else
        {
            correctBtn = false;
            conseqBtns = 0;
            totalPoints -= 5;
            if (totalPoints < 0)
                totalPoints = 0; 
            
            currentTime += -0.50f;
        }
        addedPoints = totalPoints - nowPoints;
        ShowScoreChange(addedPoints, btnObj);
    }

    // Update is called once per frame 
    void Update()
    {
        // UpdateScore(totalPoints);
        currentScoreLbl.text = totalPoints.ToString();
        // roundTimeStart -= Time.deltaTime;
        // currentTimeLbl.text = roundTimeStart.ToString("0.0");
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
        SetCurrentGameState();
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

    private void ShowScoreChange (int change, GameObject pointParent)
    {
        // Transform pointParentTransform = transform.LookAt(pointParent.transform);
        var inst = Instantiate(scoreChangePrefab, pointParent.transform.position, Quaternion.identity);
        inst.transform.SetParent(pointParent.transform, true);

        RectTransform rect = inst.GetComponent<RectTransform>();
        Text text = inst.GetComponent<Text>();
        text.text = (change > 0 ? "+ " : change < 0 ? "- " : "") + change.ToString();
        text.color = change > 0 ? addPointsColor : change < 0 ? subtractPointsColor : zeroPointsInvisible;

        LeanTween.move(rect, endPoint.anchoredPosition, 0.9f).setOnComplete(() => {Destroy(inst);});
        LeanTween.alphaText(rect, 0.25f, 1.25f);
    }
    
    // void UpdateScore(int totPoints)
    // {, 1.5
        // currentScoreLbl.text = totalPoints.ToString();
        // return currentColorLbl.text; (if method returns string)
    // }

    public void SetCurrentGameState()
    {
        //if /*time’s out and not enough buttons pressed*/
        lastScoreLbl.text = currentScoreLbl.text;
        // highScoreLbl.text = lastScoreLbl.text;
        if (currentState != gameStatus.menu && currentTime <= 0.0)
        {
            // audioSource.PlayOneShot(sfxGameOver);
            if (int.Parse(lastScoreLbl.text) > int.Parse(highScoreLbl.text))
            {
                highScoreLbl.text = lastScoreLbl.text;
            }
            // PlayerPrefs.SetString("HighScore", highScoreLbl.text);
            SavePrefs(int.Parse(highScoreLbl.text));
            roundNum = 0;
            correctBtnNumInRound = 0;
            totalBtnNumInRound = 6;
            currentState = gameStatus.gameover;
            ShowMenu();
            conseqBtns = 0;
            currentRoundLbl.text = "ROUND " + roundNum.ToString() + ": " + correctBtnNumInRound.ToString() + "/" + totalBtnNumInRound.ToString();
            // Debug.Log("currT: " + currentTime + " " + "RtimeSt: " + roundTimeStart);
            StartTime();
        }
        // else if (/*round is zero and zero keys are missed*/)
        // {
            // currentState = gameStatus.play;
        // }

        //TO DO:
        //if colorsTapped = ColorsToTap
        //currectState = gameStatus.nextround; 
        //(will this even work or should I have a separate method instead of using gameStatus?)
    }

    public void ShowMenu()
    {
        switch (currentState)
        {
            case gameStatus.gameover:
                playBtnLbl.text = "Play Again";
                // lastScoreLbl.text = currentScoreLbl.text;
                playScreen.SetActive(false);
                menuScreen.SetActive(true);
                break;
            case gameStatus.play:
                // StartTime();
                playScreen.SetActive(true);
                menuScreen.SetActive(false);
                
                break;
            case gameStatus.menu:
                playBtnLbl.text = "Play";
                playScreen.SetActive(false);
                menuScreen.SetActive(true);
                break;

            //TO DO:
            case gameStatus.nextround:
                // roundNum += 1;
                // correctBtnNumInRound = 0;
                // roundTimeStart -= 0.3f;
                // if (roundNum % 2 == 0)
                // {
                //     totalBtnNumInRound += 1;
                // }
                //update the roundNum
                //reset time
                //Score + (roundNum)*10
                break;
        }
        // playBtn.gameObject.SetActive(true);
    }
    private void SavePrefs(int lastScore)
    {
        PlayerPrefs.SetInt("HighScore", lastScore);
        PlayerPrefs.Save();
    }
    // PlayerPrefs.SetInt(“HighScore”, 50);

    private int LoadedPrefs()
    {
        int loadedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        return loadedHighScore;
    }

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

      // public void IsRoundOver()
    // {
    //     //totalEscapedLbl.text = "Escaped " + TotalEscaped + "/10";
    //     // if (/*num of correct tiles pressed) == total tiles for this round*/)
    //     // {
    //     //     //have the number of tiles to press increase depending on how far into the game the player is
    //     //     SetCurrentGameState();
    //     //     ShowMenu();
    //     // }
    // }
}

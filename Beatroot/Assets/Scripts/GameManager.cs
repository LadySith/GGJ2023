using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using MoreMountains.Feedbacks;

public class GameManager : MonoBehaviour
{
    public static event EventHandler OnStartPlayingMusic;
    public static GameManager instance;
    public AudioSource theMusic;
    public bool startPlaying;
    public bool hasPlayerTwo = false;
    public BeatScroller theBs;
    public int maxPlays = 2;
    public int current = 0;
    [Header("Score")]
    public int currentScore;
    public int playerTwoScore;
    public int currentScoreMultiplierThreshold;
    public AnimationCurve scoreMultiplierScaler, thresholdScaler;
    [Header("Score UI")]
    public TextMeshProUGUI scoreTextPlayer1;
    public TextMeshProUGUI scoreTextPlayer2;
    public TextMeshProUGUI scoreMultiplierText;

    private float currentTime = 0;
    private float clipLength = 0;
    [Header("Feedback")]
    public MMF_Player rightNoteFeedback;
    public MMF_Player wrongNoteFeedback;

    [Header("Game end ui")]
    public GameObject endScreen;
    public GameObject playerOneStats, playerTwoStats;
    public TextMeshProUGUI playeOneScroeState, playerTwoScoreState;

    private void Awake()
    {
        instance = this;
        clipLength = theMusic.clip.length;
        endScreen.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBs.hasStarted = true;
                theMusic.Play();
                current += 1;
                OnStartPlayingMusic?.Invoke(this, EventArgs.Empty);
            }
        }
        else
        {
            currentTime += Time.deltaTime;
            if (currentTime > 0 && currentTime > clipLength)
            {
                current += 1;
                currentTime = 0;
                OnStartPlayingMusic?.Invoke(this, EventArgs.Empty);
            }

            if(current > maxPlays)
            {
                theMusic.Stop();
                EndGame();
            }
        }

    }


    public void Hit(int player = 1)
    {
        if (player == 1)
        {

            currentScore += 100;
        }
        else
        {
            playerTwoScore += 100;

        }
        if (player == 1)
        {

            scoreTextPlayer1.SetText($"Score: {currentScore}");
        }
        else
        {

            scoreTextPlayer2.SetText($"Score: {playerTwoScore}");
        }
        rightNoteFeedback?.PlayFeedbacks();
        print("yes");
    }

    public void Missed(int player = 1)
    {
        wrongNoteFeedback?.PlayFeedbacks();
        print("miss");
    }

    public void EndGame()
    {
        endScreen.SetActive(true);
        playerOneStats.SetActive(true);
        playerTwoStats.SetActive(hasPlayerTwo);
        playeOneScroeState.SetText(currentScore.ToString());
        playerTwoScoreState.SetText(playerTwoScoreState.ToString());
    }
}

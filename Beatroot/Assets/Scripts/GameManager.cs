using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using MoreMountains.Feedbacks;

public class GameManager : MonoBehaviour
{
    public static event EventHandler OnStartPlayingMusic,OnEndMusic;
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
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            clipLength = theMusic.clip.length;
            endScreen.SetActive(false);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        hasPlayerTwo = ChangeScene.twoPlayerMode;
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

            scoreTextPlayer1.SetText(currentScore.ToString());
        }
        else
        {

            scoreTextPlayer2.SetText(playerTwoScore.ToString());
        }
        rightNoteFeedback?.PlayFeedbacks();
        NotePlayer.instance.PlayNote();
    }

    public void Missed(int player = 1)
    {
        wrongNoteFeedback?.PlayFeedbacks();
        NotePlayer.instance.MissNote();
    }

    public void EndGame()
    {
        endScreen.SetActive(true);
        playerOneStats.SetActive(true);
        playerTwoStats.SetActive(hasPlayerTwo);
        playeOneScroeState.SetText(currentScore.ToString());
        playerTwoScoreState.SetText(playerTwoScore.ToString());
        OnEndMusic?.Invoke(this, EventArgs.Empty);
    }

    public void setPlayers(int players)
    {
        if (players == 1)
        {
            hasPlayerTwo = false;
        }

        else
        {
            hasPlayerTwo = true;
        }
    }
}

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
    public BeatScroller theBs;
    [Header("Score")]
    public int currentScore;
    public int currentScoreMultiplierThreshold;
    public AnimationCurve scoreMultiplierScaler, thresholdScaler;
    [Header("Score UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreMultiplierText;

    private float currentTime = 0;
    private float clipLength = 0;
    [Header("Feedback")]
    public MMF_Player rightNoteFeedback;
    public MMF_Player wrongNoteFeedback;

    private void Awake()
    {
        instance = this;
        clipLength = theMusic.clip.length;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBs.hasStarted = true;
                theMusic.Play();
                OnStartPlayingMusic?.Invoke(this, EventArgs.Empty);
            }
        }
        else
        {
            currentTime += Time.deltaTime;
            if(currentTime>0 && currentTime>clipLength)
            {
                currentTime = 0;
                OnStartPlayingMusic?.Invoke(this, EventArgs.Empty);
            }
        }

    }


    public void Hit()
    {
        currentScore += 100;
        scoreText.SetText($"Score: {currentScore}");
        rightNoteFeedback?.PlayFeedbacks();
        print("yes");
    }

    public void Missed()
    {
        wrongNoteFeedback?.PlayFeedbacks();
        print("miss");
    }
}

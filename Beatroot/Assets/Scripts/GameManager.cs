using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
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

    private void Awake()
    {
        instance = this;
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
            }
        }
    }


    public void Hit()
    {
        currentScore += 100;
        scoreText.SetText($"Score: {currentScore}");
    }

    public void Missed()
    {
        print("miss");
    }
}

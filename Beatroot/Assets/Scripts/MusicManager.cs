using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;
    public AudioSource menuMusic;

    public static MusicManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<MusicManager>();

                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            Play();
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
            {
                Play();
                Debug.Log("IsnotNull");
                Destroy(this.gameObject);
            }
        }

    }

    public void Start()
    {
        if (!MusicManager.instance.menuMusic.isPlaying) MusicManager.instance.Play();
    }

    public void Update()
    {
        if (this != _instance)
        {
            _instance = null;
        }
    }

    public void Play()
    {
        menuMusic.Play();
    }
}

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
            Debug.Log("Null");
            //If I am the first instance, make me the Singleton
            _instance = this;
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

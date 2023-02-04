using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMusicScript : MonoBehaviour
{
    private static BGMusicScript _instance = null;
    public static BGMusicScript instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        if ( _instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            instance.GetComponent<AudioSource>().Stop();
        }
    }
}

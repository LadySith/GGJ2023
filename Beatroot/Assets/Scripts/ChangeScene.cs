using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static ChangeScene instance;
    public static bool twoPlayerMode = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    private void Update()
    {
        
    }

    public void load1Player()
    {
        twoPlayerMode = false;
        MoveToScene(1);
    }

    public void load2Player()
    {
        twoPlayerMode = true;
        MoveToScene(1);
    }
}

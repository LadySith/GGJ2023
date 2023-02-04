using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    private void Start()
    {
        
    }

    public void load1Player()
    {
        //set to 1 player
        MoveToScene(0);
    }

    public void load2Player()
    {
        //set to 2 players
        MoveToScene(0);
    }
}

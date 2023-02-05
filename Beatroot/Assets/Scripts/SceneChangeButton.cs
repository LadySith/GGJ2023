using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPlayer1()
    {
        ChangeScene.instance.load1Player();
    }

    public void LoadPlayer2()
    {
        ChangeScene.instance.load2Player();
    }

    public void LoadMainMenu()
    {
        ChangeScene.instance.MoveToScene(0);
    }
}

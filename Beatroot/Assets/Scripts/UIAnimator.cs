using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimator : MonoBehaviour
{
    public GameObject vinyl;
    public GameObject title;
    public GameObject player1Button;
    public GameObject player2Button;
    public GameObject aboutButton;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.rotateAroundLocal(vinyl, Vector3.forward, -360, 10f).setLoopClamp();
        LeanTween.scale(title, new Vector3(0.275f, 0.275f, 0.275f), 2f).setEase(LeanTweenType.linear).setLoopPingPong();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NoteObject : MonoBehaviour
{

    public bool canBePressed;

    public KeyCode keyToPress;

    [Header("For player")]
    public bool isPlayerOne = true;
    public KeyCode playerOneKeyCode;
    public KeyCode playerTwoKeyCode;
    // Start is called before the first frame update
    void Start()
    {
        keyToPress = isPlayerOne?playerOneKeyCode:playerTwoKeyCode;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown( keyToPress))
        {
            if (canBePressed)
            {
                GameManager.instance.Hit();
                gameObject.SetActive(false);

            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            GameManager.instance.Missed();
            canBePressed = false;
        }
    }
}

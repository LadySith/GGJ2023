using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer rend;
    public Color defaultColor;
    public Color pressedColor;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.color = defaultColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            rend.color = pressedColor;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            rend.color = defaultColor;
        }
    }
}

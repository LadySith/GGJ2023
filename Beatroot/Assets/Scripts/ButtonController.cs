using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = defaultImage;
        rend.size = rend.size / 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            rend.sprite = pressedImage;
            rend.size = rend.size / 2.0f;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            rend.sprite = defaultImage;
            rend.size = rend.size / 2.0f;
        }
    }
}

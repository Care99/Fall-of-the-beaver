using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchButton2 : MonoBehaviour
{
    public SpriteRenderer spriteButton;
    bool teclaX = true;
    // Start is called before the first frame update
    void Start()
    {
        spriteButton = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        teclaX = Input.GetKeyDown("x");
        if (teclaX)
        {
            spriteButton.color = Color.green;
        }
        else
        {
            spriteButton.color = Color.white;
        }
    }
}

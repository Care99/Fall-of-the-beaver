using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchButton1 : MonoBehaviour
{
    public SpriteRenderer spriteButton;
    bool teclaZ = true;
    // Start is called before the first frame update
    void Start()
    {
        spriteButton = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        teclaZ = Input.GetKeyDown("z");
        if (teclaZ)
        {
            spriteButton.color = Color.green;
        }
        else
        {
            spriteButton.color = Color.white;
        }
    }
}

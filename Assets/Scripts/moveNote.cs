using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveNote : MonoBehaviour
{
    public GameObject cuerpo;
    public float velocidadNota;
    // Start is called before the first frame update
    void Start()
    {
        cuerpo = gameObject.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= (Vector3)transform.right * velocidadNota * Time.fixedDeltaTime;
        if(transform.position.x < 10)
        {
            Destroy(cuerpo);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int altura = (int)transform.position.y;
        UnityEngine.KeyCode teclaPresionada = altura == 4 ? KeyCode.Z : KeyCode.X;
        if( collision.tag=="Bad" )
        {
            Debug.Log(Input.GetKeyDown(teclaPresionada));
            if( Input.GetKeyDown(teclaPresionada) )
            {
                Debug.Log(Input.GetKeyDown(teclaPresionada));
                Destroy(gameObject);
            }
        }
        if( collision.tag=="Good" )
        {
            Debug.Log(Input.GetKeyDown(teclaPresionada));
            if( Input.GetKeyDown(teclaPresionada) )
            {
                Debug.Log(Input.GetKeyDown(teclaPresionada));
                Destroy(gameObject);
            }
        }
    }
}

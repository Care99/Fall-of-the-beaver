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
        cuerpo.GetComponent<Rigidbody2D>().position = new Vector2(9, cuerpo.GetComponent<Rigidbody2D>().position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= (Vector3)transform.right * velocidadNota * Time.fixedDeltaTime;
        if(cuerpo.GetComponent<Transform>().position.x < 10)
        {
            Destroy(cuerpo);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int altura = (int)transform.position.y;
        UnityEngine.KeyCode teclaPresionada = altura == 4 ? KeyCode.Z : KeyCode.X;
        /*&&Input.GetKeyDown(teclaPresionada))*/
        /*&&Input.GetKeyDown(teclaPresionada)*/
        if (collision.tag == "Bad" || collision.tag == "Good")
        {
            Destroy(gameObject);
        }
    }
}

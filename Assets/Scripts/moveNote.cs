using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveNote : MonoBehaviour
{
    public Rigidbody2D cuerpo;
    public float velocidadNota;
    public int alturaNota;
    Vector2 velocidad;
    // Start is called before the first frame update
    void Start()
    {
        cuerpo = gameObject.GetComponent<Rigidbody2D>();
        cuerpo.position = new Vector2(4, alturaNota);
        velocidad = new Vector2(-velocidadNota, 0);
    }

    // Update is called once per frame
    void Update()
    {
        cuerpo.MovePosition(cuerpo.position + velocidad * Time.fixedDeltaTime);
    }
}

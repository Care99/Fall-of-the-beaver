using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidoBotonesInput : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] arregloNotas = new AudioClip[8];
    public AudioSource reproducirNota;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool botonZ = false;
        bool botonX = false;
        int indiceNota = (int)Random.Range(0, 7);
        botonZ = Input.GetKeyDown(KeyCode.Z);
        botonX = Input.GetKeyDown(KeyCode.X);
        if( botonZ || botonX )
        {
            reproducirNota.clip = arregloNotas[indiceNota];
            reproducirNota.Play();
        }
    }
}

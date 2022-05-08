using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class internalScore : MonoBehaviour
{
    public SpriteRenderer[] troncos;
    int puntaje = 0;
    int puntajeConsecutivo = 0;
    int notasFallidas = 0;
    int cantidadTroncos = 0;
    // Start is called before the first frame update
    void Start()
    {
        troncos = gameObject.GetComponentsInChildren<SpriteRenderer>();
        troncos[0].GetComponent<SpriteRenderer>().enabled = false;
        troncos[1].GetComponent<SpriteRenderer>().enabled = false;
        troncos[2].GetComponent<SpriteRenderer>().enabled = false;
        troncos[3].GetComponent<SpriteRenderer>().enabled = false;
        troncos[4].GetComponent<SpriteRenderer>().enabled = false;
        troncos[5].GetComponent<SpriteRenderer>().enabled = false;
    }
    void gameOver()
    {

    }
    // Update is called once per frame
    void actualizarTroncos(int cantidadTroncos)
    {
        Debug.Log(cantidadTroncos);
        if (cantidadTroncos < 1)
        {
            Debug.Log("Perdiste!");
        }
        else
        {
            troncos[cantidadTroncos - 1].GetComponent<SpriteRenderer>().enabled = !troncos[cantidadTroncos - 1].GetComponent<SpriteRenderer>().isVisible;
        }
    }
    void Update()
    {
        //bool chequeoNota = true;
        bool teclaZ = false;
        bool teclaX = false;
        teclaZ = Input.GetKeyDown("z");
        teclaX = Input.GetKeyDown("x");
        //bool chequeoNota = inputNota();
        if (teclaZ)
        {
            puntaje+=50;
            puntajeConsecutivo++;
            if( puntajeConsecutivo%2 == 0 && cantidadTroncos < 7 )
            {
                cantidadTroncos++;
                actualizarTroncos(cantidadTroncos);
            }
        }
        else if(teclaX)
        {
            puntajeConsecutivo = 0;
            notasFallidas++;
            if( notasFallidas%3 == 0 )
            {
                if(cantidadTroncos == 7)
                {
                    cantidadTroncos--;
                }
                actualizarTroncos(cantidadTroncos);
                cantidadTroncos--;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarNotas : MonoBehaviour
{
    public GameObject prefabNota;
    List<GameObject> notasSuperiores;
    List<GameObject> notasInferiores;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int ubicacion = (int)System.Math.Floor(Random.Range((float)1.00,(float)2.99));
        if(ubicacion==1)
        {
            notasSuperiores.Add( Instantiate(prefabNota) as GameObject);
            notasSuperiores[0].GetComponent<Rigidbody2D>().position = new Vector2(9,4);
            notasSuperiores[0].GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else
        {
            notasInferiores.Add(Instantiate(prefabNota) as GameObject);
            notasInferiores[0].GetComponent<Rigidbody2D>().position = new Vector2(9, 2);
            notasInferiores[0].GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }

    
}

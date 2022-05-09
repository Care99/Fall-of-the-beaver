using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarNotas : MonoBehaviour
{
    public GameObject prefabNota;
    GameObject notaInstanciada;
    // Start is called before the first frame update
    void generarNota()
    {
        int ubicacion = (int)Random.Range((float)0.00,(float)1.99);
        Vector3 posicionNota = new Vector3(9,2+(2*ubicacion),0);
        notaInstanciada = Instantiate(prefabNota,posicionNota,Quaternion.identity) as GameObject;
    }
    void Start()
    {
        InvokeRepeating("generarNota",0,1);   
    }

    // Update is called once per frame
    void Update()
    {

    }

    
}

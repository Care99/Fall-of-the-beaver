using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarNotas : MonoBehaviour
{
    public GameObject prefabNota;
    GameObject notaInstanciada;
    public int tiempo;
    // Start is called before the first frame update
    void generarNota()
    {
        int ubicacion = Random.Range(0,2);
        Vector3 posicionNota = new Vector3(6.5f,3+(ubicacion),0);
        notaInstanciada = Instantiate(prefabNota,posicionNota,Quaternion.identity) as GameObject;
    }
    public void StartGenerator()
    {
        InvokeRepeating("generarNota",0,tiempo);   
    }
       
}

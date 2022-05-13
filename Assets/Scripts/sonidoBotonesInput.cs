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
        GameManager.current.botonZ = Input.GetKeyDown(KeyCode.Z);
        GameManager.current.botonX = Input.GetKeyDown(KeyCode.X);
        if((GameManager.current.inBadZone || GameManager.current.inGoodZone) && (GameManager.current.botonZ || GameManager.current.botonX ))
        {
            int indiceNota = (int)Random.Range(0, 7);
            reproducirNota.clip = arregloNotas[indiceNota];
            reproducirNota.Play();
            Destroy(GameManager.current.tmpNote);
            if (GameManager.current.inBadZone)
            {
                GameManager.current.badPoints++;
                GameManager.current.badPlay();
                GameManager.current.castorAnimation("isBad", true);
            }
            else if (GameManager.current.inGoodZone)
            {
                GameManager.current.goodPoints++;
                GameManager.current.goodPlay();
                GameManager.current.castorAnimation("isGood", true);
                GameManager.current.notasGood();
                GameManager.current.showGoodPoint();
            }
            GameManager.current.updatePoints();
            GameManager.current.botonX = false;
            GameManager.current.botonZ = false;
            GameManager.current.inBadZone = false;
            GameManager.current.inGoodZone = false;
        }
    }
}

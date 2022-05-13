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

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.current.startThisGame)
        {
            int speed = Random.Range(1, 5);
            transform.position -= (Vector3)transform.right * (velocidadNota * speed) * Time.fixedDeltaTime;
        }   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int altura = (int)transform.position.y;
        UnityEngine.KeyCode teclaPresionada = altura == 4 ? KeyCode.Z : KeyCode.X;
        switch (collision.tag)
        {
            case "Bad":
                GameManager.current.inGoodZone = false;
                GameManager.current.inBadZone = true;
                GameManager.current.tmpNote = gameObject;
                break;
            case "Good":
                GameManager.current.inBadZone = false;
                GameManager.current.inGoodZone = true;
                GameManager.current.tmpNote = gameObject;
                break;
            case "Destroy":
                GameManager.current.inBadZone = false;
                GameManager.current.inGoodZone = false;
                GameManager.current.badPoints++;
                GameManager.current.castorAnimation("isBad", true);
                GameManager.current.badPlay();
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

}

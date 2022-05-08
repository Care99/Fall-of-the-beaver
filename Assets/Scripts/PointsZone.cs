using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsZone : MonoBehaviour
{
    public string goodTag, badTag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(goodTag))
        {
            GameManager.current.points++;
        }
        else if (collision.CompareTag(badTag))
        {
            GameManager.current.points--;
        }
        GameManager.current.updatePoints();
    }
}

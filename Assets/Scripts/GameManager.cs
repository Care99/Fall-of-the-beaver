using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager current = null;
    private static bool created;
    public GameObject panelInstructions;

    [Header("Points")]
    public int points;
    public int maxPoints;
    public Text txtPoints;

    [Header("End scene")]
    public GameObject panelEnd;
    public Image imgEnd;
    public Sprite spriteGood, spriteBad;
    
    public bool endThisGame = false;

    [Header("Audio")]
    [SerializeField] private AudioSource goodSound;
    [SerializeField] private AudioSource badSound;

    // Start is called before the first frame update
    void Start()
    {
        if (!created)
        {
            DontDestroyOnLoad(this);
            created = true;
            current = this;
        }
        else
        {
            Destroy(gameObject);
        }
        points=0;
    }

    // Update is called once per frame
    void Update()
    {
        if (points < 0 || points > maxPoints)
        {
            if (!endThisGame)
            {
                StartCoroutine(ieEndThisGame());
            }
        }
    }

    public void StartThisGame()
    {
        //comenzar movimiento de los elementos
    }

    public void hideInstructions()
    {
        panelInstructions.SetActive(false);
        StartThisGame();
    }

    IEnumerator ieEndThisGame()
    {
        endThisGame = true;
        yield return new WaitForSeconds(2.75f);
        imgEnd.sprite = points < 0 ? spriteBad : spriteGood;
        panelEnd.gameObject.SetActive(true);
    }

    public void goodPlay()
    {
        goodSound.Play();
    }

    public void badPlay()
    {
        badSound.Play();
    }

    public void ChangeSceneTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void updatePoints()
    {
        txtPoints.text = points + "";
    }
}

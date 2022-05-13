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
    public int goodPoints;
    public int maxPoints;
    public int badPoints;
    public int maxBadPoints;
    [SerializeField] private Text txtPoints;
    [SerializeField] private Text txtBadPoints;
    public bool inBadZone = false;
    public bool inGoodZone = false;
    public GameObject tmpNote;
    [SerializeField] private GameObject[] goGoodPoints;
    public bool botonZ = false;
    public bool botonX = false;

    [Header("Scene")]
    [SerializeField] private GameObject panelEnd;
    [SerializeField] private GameObject goGoodEnd;
    public bool endThisGame = false;
    public bool startThisGame = false;

    [Header("Audio")]
    [SerializeField] private AudioSource goodSound;
    [SerializeField] private AudioSource badSound;
    [SerializeField] private AudioSource track;

    [Header("Animation")]
    public Animator castor;

    [Header("Troncos")]
    [SerializeField] private GameObject[] troncos;
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
        goodPoints = 0;
        badPoints = 0;
        //track.Play();
        panelInstructions.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!endThisGame && (goodPoints > maxPoints || badPoints> maxBadPoints ))
        {
            StartCoroutine(ieEndThisGame());
        }
    }

    public void StartThisGame()
    {
        startThisGame = true;
        FindObjectOfType<generarNotas>().StartGenerator();
    }

    public void hideInstructions()
    {
        panelInstructions.SetActive(false);
        StartThisGame();
    }

    IEnumerator ieEndThisGame()
    {
        endThisGame = true;
        startThisGame = false;
        yield return new WaitForSeconds(0.75f);
        panelEnd.gameObject.SetActive(true);
        if(badPoints> maxBadPoints)
        {
            castor.SetBool("isBad", true);
        }
        else
        {
            goGoodEnd.SetActive(true);
            castor.SetBool("isGood", true);
        }
        moveNote[] moveNotes = FindObjectsOfType<moveNote>();
        foreach (moveNote moveN in moveNotes)
        {
            Destroy(moveN.gameObject);
        }
    }

    public void goodPlay()
    {
        goodSound.Play();
    }

    public void badPlay()
    {
        badSound.Play();
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void ChangeSceneTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void updatePoints()
    {
        txtPoints.text = goodPoints + "";
        txtBadPoints.text = badPoints + "";
    }

    public void castorAnimation(string sVariable, bool value) {
        StartCoroutine(ieCastorAnimation(sVariable, value));
    }

    IEnumerator ieCastorAnimation(string sVariable, bool value)
    {
        castor.SetBool(sVariable, value);
        yield return new WaitForSeconds(0.75f);
        castor.SetBool(sVariable, !value);
    }

    public void notasGood()
    {
        if ((goodPoints % 2) == 0)
        {
            foreach (GameObject tronco in troncos)
            {
                if (!tronco.activeInHierarchy)
                {
                    tronco.SetActive(true);
                    break;
                }
            }
        }
    }

    public void showGoodPoint()
    {
        StartCoroutine(ieShowGoodPoint());
    }

    IEnumerator ieShowGoodPoint()
    {
        goGoodPoints[0].SetActive(botonZ);
        goGoodPoints[1].SetActive(botonX);
        yield return new WaitForSeconds(0.75f);
        goGoodPoints[0].SetActive(false);
        goGoodPoints[1].SetActive(false);
    }
}

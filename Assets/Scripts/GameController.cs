using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject pnlEndGame;
    public Button btnRestart;
    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnClick;
    public Text txtPoint;

    private int gamePoint;

    AudioSource ad;

    // Start is called before the first frame update
    void Start()
    {
        pnlEndGame.SetActive(false);
        Time.timeScale = 1;
        ad = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ButtonHover()
    {
        btnRestart.GetComponent<Image>().sprite = btnHover;
    }

    public void ButtonIdle()
    {
        btnRestart.GetComponent<Image>().sprite = btnIdle;
    }

    public void ButtonClick()
    {
        btnRestart.GetComponent<Image>().sprite = btnClick;
    }

    public void EndGame()
    {
        ad.Play();
        pnlEndGame.SetActive(true);
        Time.timeScale = 0;
    }
}

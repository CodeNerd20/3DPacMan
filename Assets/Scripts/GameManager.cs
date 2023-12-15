using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public GameObject pellet;
    public bool hasPowerup;
    public GameObject Player;
    public bool isActive;
    public GameObject ScaredGhost;
    public Button NewGameButton;
    public TextMeshProUGUI youWinText;

    //Scoring
    private int score;
    public TextMeshProUGUI scoreText;
    public int pointValue;

    //Game Over
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;

    [Header("Ghosts")]
    public InkyControls inky;
    public BlinkyControls blinky;
    public PinkyControls pinky;
    public ClydeControls clyde;

    public Dot[] dots;


    // Start is called before the first frame update
    void Start()
    {
        //Score
        score = 0;
        UpdateScore(0);

        isGameActive = true;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dots = GameObject.FindObjectsOfType<Dot>();
        if(dots.Length == 0)
        {
            //&& NewGameButton.isActiveAndEnabled && Input.GetButtonDown("NewGame")
            YouWin();
        }

        if (restartButton.isActiveAndEnabled && Input.GetButtonDown("Restart"))
        {
            RestartGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            UpdateScore(pointValue);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void YouWin()
    {
        youWinText.gameObject.SetActive(true);
        isGameActive = false;
        NewGameButton.gameObject.SetActive(true);
        if (Input.GetButtonDown("NewGame"))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        Debug.Log("RESTART THE GAME ETHAN!");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ScareGhosts()
    {
        Debug.Log("SCARE THE GHOSTS");
        blinky.GetScared();
        inky.GetScared();
        pinky.GetScared();
        clyde.GetScared();
        //Don't let them kill you when you touch them while scared is active
    }
}



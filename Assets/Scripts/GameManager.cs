using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pellet;

    //Scoring
    private int score;
    public TextMeshProUGUI scoreText;
    public int pointValue;

    //Game Over
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        //Score
        score = 0;
        UpdateScore(0);

        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {

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

    public void RestartGame()
    {
        Debug.Log("RESTART THE GAME ETHAN!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}



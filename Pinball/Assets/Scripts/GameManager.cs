using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform gameOverPlane;
    public Transform ball;
    public GameObject gameOverUI;
    public TextMeshProUGUI score;
    private bool inGame = true;
    private void Start()
    {
        if (score != null && gameOverUI != null)
        {
            SetScore(0);
            gameOverUI.SetActive(false);
        }
    }
    public void AddScore(int scorePerBounce)
    {
        int scoreVal = int.Parse(score.text);
        scoreVal += scorePerBounce;
        score.text = scoreVal.ToString();
    }
    public int GetScore()
    {
        int scoreVal = int.Parse(score.text);
        return scoreVal;
    }
    void SetScore(int scorePerBounce)
    {
        score.text = scorePerBounce.ToString();
    }
    void SetScore(String scorePerBounce)
    {
        score.text = scorePerBounce;
    }
    private void FixedUpdate()
    {
        if (ball != null)
        {
            if (ball.position.y < gameOverPlane.position.y&&inGame)
            {
                inGame = false;
                gameOver();
            }
        }
    }

    public void gameOver()
    {
        AudioManager.instance.StartPlaying("loss");
        AudioManager.instance.StartPlaying("loss2");
        gameOverUI.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

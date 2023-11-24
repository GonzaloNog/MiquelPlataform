using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Security.Authentication.ExtendedProtection;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI textoTiempo;
    public TextMeshProUGUI finalScore;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    void Start()
    {
        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        score.text = "score: " + LevelManager.instance.getPoints();
    }

    public void UpdateUI()
    {
        score.text = "Score: " + LevelManager.instance.getPoints();
        textoTiempo.text = "Time: " + Mathf.CeilToInt(LevelManager.instance.getTimeRestante()).ToString() + "s";
        coins.text = "Coins: " + LevelManager.instance.getCoins();
        gameOverPanel.SetActive(LevelManager.instance.getGameOver());
    }
    public void WinUI()
    {
        Time.timeScale = 0;
        finalScore.text = "Score: " + LevelManager.instance.getPoints();
        winPanel.SetActive(true);
    }

    public void ResetGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

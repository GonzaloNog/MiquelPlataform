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
    public GameObject gameOverPanel;
    void Start()
    {
        gameOverPanel.SetActive(false);
        score.text = "score: " + LevelManager.instance.getPoints();
    }

    public void UpdateUI()
    {
        score.text = "score: " + LevelManager.instance.getPoints();
        gameOverPanel.SetActive(LevelManager.instance.getGameOver());
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

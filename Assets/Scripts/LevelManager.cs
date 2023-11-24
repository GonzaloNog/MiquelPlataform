using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public CharacterControler player;
    public UIManager ui;
    public AudioManager audioManager;
    public TextMeshProUGUI textoTiempo; 
    public float tiempoTotal = 60f;
    private float tiempoRestante;
    private int points;
    private bool gameOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        tiempoRestante = tiempoTotal;
    }

    private void Update()
    {
        tiempoRestante -= Time.deltaTime;
        textoTiempo.text = "Time: " + Mathf.CeilToInt(tiempoRestante).ToString() + "s";
        if(tiempoRestante <= 0f && !gameOver)
        {
            setGameOver(true);
            tiempoRestante = 0;
        }
    }

    public CharacterControler getCharacterControler()
    {
        return player;
    }

    //Set and get
    public int getPoints()
    {
        return points;
    }
    public void setPoints(int _points)
    {
        points += _points;
        ui.UpdateUI();
    }

    public bool getGameOver()
    {
        return gameOver;
    }
    public void setGameOver(bool _gameOver)
    {
        gameOver = _gameOver;
        ui.UpdateUI();
    }

}

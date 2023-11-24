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
    public AudioManager am;

    public float tiempoTotal = 60f;
    private float tiempoRestante;
    private float timeUpdateControl;
    private int points;
    private int coins;
    private bool gameOver = false;
    private bool gameWin = false;

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
        coins = 0;
        tiempoRestante = tiempoTotal;
        timeUpdateControl = tiempoTotal;
    }

    private void Update()
    {
        if(tiempoRestante >= 0 && !gameWin)
        {
            tiempoRestante -= Time.deltaTime;

            if(tiempoRestante < timeUpdateControl && tiempoRestante > (timeUpdateControl - 1))
            {
                timeUpdateControl--;
                ui.UpdateUI();
            }
            if (tiempoRestante <= 0f && !gameOver)
            {
                setGameOver(true);
                Time.timeScale = 0;
                tiempoRestante = 0;
            }
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
        if(_points > 1)
        {
            StartCoroutine(newPointsAnim(_points));
        }
        else
        {
            points += _points;
            ui.UpdateUI();
        }       
    }

    public bool getGameOver()
    {
        return gameOver;
    }
    public void setGameOver(bool _gameOver)
    {
        gameOver = _gameOver;
        if(gameOver)
            am.newSFX("lose");
        ui.UpdateUI();
    }

    public int getCoins()
    {
        return coins;
    }
    public void setCoins(int _coins)
    {
        coins = _coins;
    }

    public float getTimeRestante()
    {
        return tiempoRestante;
    }
    public void setWin(bool win)
    {
        gameWin = win;
    }
    public bool getWin()
    {
        return gameWin;
    }

    IEnumerator newPointsAnim(int _points)
    {
        int temp = points;
        float timeMode = 0.05f;
        if (_points < 5)
            timeMode = 0.2f;
        while((_points + temp) > points)
        {
            points++;
            ui.UpdateUI();
            yield return new WaitForSeconds(timeMode);
        }
    }

}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public CharacterControler player;
    public UIManager ui;
    public AudioManager audio;
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

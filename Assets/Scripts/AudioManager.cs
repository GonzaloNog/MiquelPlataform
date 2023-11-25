using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip musica;
    public AudioClip musicaWin;
    public AudioClip jump;
    public AudioClip dead;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip coin;
    public AudioClip enemyDead;

    public AudioClip error;

    public AudioSource music;
    public AudioSource SFX;
    void Start()
    {
        music.clip = musica;
        music.volume = GameManager.instance.getMusicVolum();
        SFX.volume = GameManager.instance.getSFXVolum();
        music.Play();
    }

    public void newSFX(string efectName)
    {
        SFX.Stop();
        switch (efectName)
        {
            case "jump":
                SFX.clip = jump;
                break;
            case "dead":
                SFX.clip = dead;
                break;
            case "win":
                SFX.clip = win;
                break;
            case "lose":
                SFX.clip = lose;
                break;
            case "coin":
                SFX.clip = coin;
                break;
            case "enemyDead":
                SFX.clip = enemyDead;
                break;
            default: 
                music.clip = error;
                break;
        }
        SFX.Play();
    }
}

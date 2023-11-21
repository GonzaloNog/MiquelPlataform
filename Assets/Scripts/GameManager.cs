using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float musicVolum = 1;
    private float sfxVolume = 1;

    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    //set and get
    public float getMusicVolum()
    {
        return musicVolum;
    }
    public void setMusicVolum(float vol)
    {
        musicVolum = vol;
    }

    public float getSFXVolum()
    {
        return sfxVolume;
    }
    public void setSFXVolum(float vol)
    {
        sfxVolume = vol;
    }
}

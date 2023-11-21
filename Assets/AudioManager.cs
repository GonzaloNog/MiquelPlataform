using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip musica;
    public AudioClip jump;
    public AudioClip dead;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip enemyDead;

    public AudioSource music;
    public AudioSource SFX;
    void Start()
    {
        //music.clip = musica;
        music.volume = GameManager.instance.getMusicVolum();
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioClip musicClip;
    public AudioSource buttonSource;
    public AudioClip buttonClip;
    public AudioSource gameOverSource;
    public AudioClip gameoverClip;
   
    public void LoadMenu()
    {
        
        buttonSource.Play();
        SceneManager.LoadScene("Menu");
       

    }
    void Start()
    {
        buttonSource.clip = buttonClip;
        gameOverSource.clip = gameoverClip;
        gameOverSource.Play();
        musicAudioSource.clip = musicClip;
        musicAudioSource.Stop();
    }
    



}

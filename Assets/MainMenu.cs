using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public AudioSource clickButtonSound;
    public AudioClip playClip;

     void Start()
    {
        clickButtonSound.clip = playClip;
    }
    public void LoadGame()
    {
        clickButtonSound.Play();
        SceneManager.LoadScene("SampleScene");
       
    }
    public void ExitGame()
    {
        clickButtonSound.Play();
        Application.Quit();
    }
}

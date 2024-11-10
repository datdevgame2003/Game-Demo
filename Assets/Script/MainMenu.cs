using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public AudioSource clickButtonSound;
    public AudioSource ExitSound;
    public AudioSource tutorialSound;
    public AudioClip playClip;
    public AudioClip tutorialClip;
    public AudioClip exitClip;
    void Start()
    {
        clickButtonSound.clip = playClip;
        tutorialSound.clip = tutorialClip;
        ExitSound.clip = exitClip;
    }
    public void LoadGame()
    {
        clickButtonSound.Play();
        SceneManager.LoadScene("Level1");
       
    }
    public void ExitGame()
    {
        ExitSound.Play();
        Application.Quit();
    }
    public void SelectTutorial()
    {
        
        SceneManager.LoadScene("Tutorial");
        tutorialSound.Play();
    }
}

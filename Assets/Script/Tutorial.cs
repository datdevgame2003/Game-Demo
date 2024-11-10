using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public AudioSource clickTSound;
    public AudioClip TClip;

    void Start()
    {
        clickTSound.clip = TClip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        clickTSound.Play();
    }
}

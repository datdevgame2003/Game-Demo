using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioManager audioManager;
    //public GameObject gamewinOj;
    public AudioSource buttonSound;
    public AudioClip buttonClip;
    public AudioSource musicAudioSource;
    public AudioClip musicClip;

    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Stop();

        buttonSound.clip = buttonClip;
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.winClip);
        }
    }
    
    void Update()
    {
        
    }
    public void LoadMenu()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Menu");


    }
}

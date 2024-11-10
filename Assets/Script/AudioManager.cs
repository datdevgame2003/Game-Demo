using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioSource vfxAudioSource;
    public AudioClip musicClip;
    public AudioClip winClip;
    
    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();
    }

   
    void Update()
    {
        
    }
    public void PlaySFX(AudioClip sfxClip)
    {
        vfxAudioSource.clip = sfxClip;
        vfxAudioSource.PlayOneShot(sfxClip);
    }
    
}

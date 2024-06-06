using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AudioManager : MonoBehaviour
{
    [Header("-----------Audio Source------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-----------Audio Clips------------")]
    public AudioClip Background;
    public AudioClip Crying;
    public AudioClip Eating;
    public AudioClip Crash;
    public AudioClip Grunt; 
    public AudioClip Om_Nom;
    public AudioClip Menu_music;

    private void Start()
    {
        musicSource.clip = Background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}

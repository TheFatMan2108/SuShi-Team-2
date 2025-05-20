using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Audio : MonoBehaviour
{
    public static Audio Instance;
    public Source[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        Source s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Source s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.pitch= 1;
            sfxSource.PlayOneShot(s.clip);
        }
    }
    public void PlaySFX(string name, bool isRandom)
    {
        Source s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.pitch = !isRandom ? 1 : UnityEngine.Random.Range(-3f, 3);
            sfxSource.PlayOneShot(s.clip);
        }
    }
}

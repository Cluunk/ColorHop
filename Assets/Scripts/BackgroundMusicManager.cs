using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class BackgroundMusicManager : MonoBehaviour
{
    public static BackgroundMusicManager Instance { get; private set; }
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioSource backgroundSource;
    
    private void Awake()
    {
        if (Instance && Instance != this)
        {
            SetBackgroundMusic(backgroundMusic);
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            SetBackgroundMusic(backgroundMusic);

        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetBackgroundMusic(AudioClip bgMusic)
    {
        if (bgMusic == null)
        {
            StartCoroutine(FadeOutMusic());
            return;
        }

        Instance.backgroundSource.clip = bgMusic;
        Instance.backgroundSource.volume = backgroundSource.volume;
        Instance.backgroundSource.Play();
    }

    private IEnumerator FadeOutMusic()
    {
        const float fadeTime = 0.5f;
        var stopwatch = Stopwatch.StartNew();

        var volume = Instance.backgroundSource.volume;
        
        while (Instance.backgroundSource.volume > 0)
        {
            Instance.backgroundSource.volume -= volume * Time.deltaTime / fadeTime;
            yield return null;
        }
        stopwatch.Stop();
        Debug.Log(stopwatch.Elapsed);
    }

    public float Volume()
    {
        return Instance.backgroundSource.volume;
    }
}

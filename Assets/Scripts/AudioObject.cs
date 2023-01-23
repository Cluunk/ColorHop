using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioObject : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private bool dontDestroyOnLoad;

    private void Awake()
    {
        if (dontDestroyOnLoad)
            DontDestroyOnLoad(gameObject);
        source.clip = SelectedClip();
        if (source.isPlaying)
            return;
        source.Play();
    }

    private void Update()
    {
        if (!source.isPlaying)
            Destroy(gameObject);
    }

    private AudioClip SelectedClip()
    {
        if (clips.Length < 1)
            return null;
        if (clips.Length == 1)
            return clips[0];

        return clips[Random.Range(0, clips.Length)];
    }
}

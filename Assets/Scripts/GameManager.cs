using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Level CurrentLevel { get; set; }
    public int Score { get; private set; }

    private void Awake()
    {
        if (Instance && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        
        DontDestroyOnLoad(gameObject);
    }


    public void LoadLevel(string level)
    {
        if (!Application.CanStreamedLevelBeLoaded(level))
            throw new Exception($"Level {level} doesn't exist");

        SceneManager.LoadScene(level);
    }

    public void AddScore(int amountToAdd)
    {
        if (amountToAdd < 0)
            return;
        Score += amountToAdd;
    }

    public void ResetScore()
    {
        Score = 0;
    }
}

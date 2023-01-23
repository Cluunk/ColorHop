using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelClock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerDisplay;
    
    [SerializeField] private float clockSpeed = 1;
    [SerializeField] private float maxTime = 350;
    public float CurrentTime { get; private set; }

    private void Start()
    {
        ResetClock();
    }

    private void ResetClock()
    {
        CurrentTime = maxTime;
    }

    private void Update()
    {
        CurrentTime -= Time.deltaTime * Mathf.Abs(clockSpeed);
        if (timerDisplay)
            DisplayTimer();
        if (CurrentTime <= 0)
        {
            //GameManager.Instance.CurrentLevel.Player.TakeDamage();
            SceneManager.LoadScene("Lose");
            ResetClock();
        }
    }

    private void DisplayTimer()
    {
        timerDisplay.text = $"{(int)CurrentTime}";
    }
    
    public void IncreaseTimer(float increaseAmount)
    {
        CurrentTime += increaseAmount;
        if (CurrentTime > maxTime)
            CurrentTime = maxTime;
    }
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelClock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerDisplay;
    
    [SerializeField] private float clockSpeed = 1;
    
    private bool started;

    private void Start()
    {
        ResetClock();
    }

    private void ResetClock()
    {
        timerDisplay.text = ((int)GameManager.Instance.CurrentTime).ToString();
    }

    public void StartClock()
    {
        started = true;
    }

    private void Update()
    {
        if (!started)
            return;
        
        GameManager.Instance.CurrentTime -= Time.deltaTime * Mathf.Abs(clockSpeed);
        if (timerDisplay)
            DisplayTimer();
        if (GameManager.Instance.CurrentTime <= 0)
        {
            //GameManager.Instance.CurrentLevel.Player.TakeDamage();
            SceneManager.LoadScene("Lose");
            ResetClock();
        }
    }

    private void DisplayTimer()
    {
        timerDisplay.text = $"{(int)GameManager.Instance.CurrentTime}";
    }
    
    public void IncreaseTimer(float increaseAmount)
    {
        GameManager.Instance.CurrentTime += increaseAmount;
        if (GameManager.Instance.CurrentTime > GameManager.MaxTime)
            GameManager.Instance.CurrentTime = GameManager.MaxTime;
    }
}

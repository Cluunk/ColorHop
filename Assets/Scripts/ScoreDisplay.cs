using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI display;
    [SerializeField] private AudioObject winSound;
    
    private IEnumerator Start()
    {
        BackgroundMusicManager.Instance.SetBackgroundMusic(null);
        display.text = $"Score: {(int)GameManager.Instance.CurrentTime}";
        yield return new WaitUntil(() => BackgroundMusicManager.Instance.Volume() <= 0);
        Instantiate(winSound);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTimer : MonoBehaviour
{
    [SerializeField] private ColorObjectManager colorManager;
    
    [SerializeField] private float timerDuration;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerDuration)
        {
            colorManager.ContinueCycle();
            timer = 0;
        }
    }
}

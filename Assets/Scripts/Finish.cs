using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.LoadLevel(nextLevel);
    }
}
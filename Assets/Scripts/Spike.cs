using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == GameManager.Instance.CurrentLevel.Player.gameObject)
            GameManager.Instance.CurrentLevel.Player.TakeDamage();
    }
}

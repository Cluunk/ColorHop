using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ColorBullet colorObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (colorObject)
        {
            if (other.GetComponent<Pickup>())
                return;
            
            var level = GameManager.Instance.CurrentLevel;
            level.ColorObjectManager.RemoveObject(colorObject);
            
            if (level.ColorObjectManager.ActiveColor == colorObject.Data.ObjectColor)
            {
                if (other.gameObject == GameManager.Instance.CurrentLevel.Player.gameObject)
                    level.Player.TakeDamage();
                Destroy(gameObject);
            }
            else
                if (other.gameObject != level.Player.gameObject)
                    Destroy(gameObject);
        }
        else
        {
            if (other.GetComponent<Pickup>())
                return;
            
            if (other.gameObject == GameManager.Instance.CurrentLevel.Player.gameObject)
                GameManager.Instance.CurrentLevel.Player.TakeDamage();
            Destroy(gameObject);
        }
    }

    public void SpawnBullet(Vector2 direction, float bulletSpeed)
    {
        if (colorObject)
            GameManager.Instance.CurrentLevel.ColorObjectManager.AddObject(colorObject);
        rb.velocity = direction.normalized * bulletSpeed;
    }
}

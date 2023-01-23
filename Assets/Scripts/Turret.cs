using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Vector2 shootDirection;

    [SerializeField] private AudioObject shootSound;

    private void Start()
    {
        InvokeRepeating(nameof(Shoot), 1f/fireRate, 1f/fireRate);
    }

    private void Shoot()
    {
        var b = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        b.SpawnBullet(shootDirection, bulletSpeed);
        if (shootSound)
            Instantiate(shootSound, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == GameManager.Instance.CurrentLevel.Player.gameObject)
            GameManager.Instance.CurrentLevel.Player.TakeDamage();
    }
}

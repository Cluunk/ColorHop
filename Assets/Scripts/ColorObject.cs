using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Collider2D))]
public abstract class ColorObject : MonoBehaviour
{
    [field:SerializeField] public ColorObjectData Data { get; private set; }

    [SerializeField] protected Collider2D[] colliders;
    
    public abstract void SetActive();

    public abstract void SetInactive();
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [field:SerializeField] public PlayerMovement Player { get; private set; }
    [field:SerializeField] public Transform LevelStart { get; private set; }
    [field:SerializeField] public LevelClock Clock { get; private set; }
    [field:SerializeField] public ColorObjectManager ColorObjectManager { get; private set; }

    private void Start()
    {
        GameManager.Instance.CurrentLevel = this;
        Player.transform.position = LevelStart.position;
    }
}

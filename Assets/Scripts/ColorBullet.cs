using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBullet : ColorSprite
{
    private void Awake()
    {
        if (GameManager.Instance.CurrentLevel.ColorObjectManager.ActiveColor == Data.ObjectColor)
            SetActive();
        else
            SetInactive();
    }

    public override void SetActive()
    {
        renderer.color = Data.ActiveColor;
    }

    public override void SetInactive()
    {
        renderer.color = Data.InactiveColor;
    }
}

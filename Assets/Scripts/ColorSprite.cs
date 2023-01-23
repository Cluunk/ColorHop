using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSprite : ColorObject
{
    [SerializeField] protected new SpriteRenderer renderer;
    
    public override void SetActive()
    {
        renderer.color = Data.ActiveColor;
        foreach (var col in colliders)
            col.enabled = true;
    }

    public override void SetInactive()
    {
        renderer.color = Data.InactiveColor;
        foreach (var col in colliders)
            col.enabled = false;
    }
}

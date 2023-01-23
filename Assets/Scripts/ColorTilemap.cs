using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class ColorTilemap : ColorObject
{
    private new Tilemap renderer;
    
    private void Awake()
    {
        renderer = GetComponent<Tilemap>();
    }

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

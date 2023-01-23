using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorObjectManager : MonoBehaviour
{
    private List<ColorObject> colorObjects;

    [field:SerializeField] public ObjectColor[] Cycle { get; private set; }
    private int currentCycleIndex;
    public ObjectColor ActiveColor { get; private set; }

    private void Start()
    {
        colorObjects = FindObjectsOfType<ColorObject>().ToList();
        SetColorActive(Cycle[0]);
    }

    public void ContinueCycle()
    {
        if (++currentCycleIndex >= Cycle.Length)
            currentCycleIndex = 0;
        SetColorActive(Cycle[currentCycleIndex]);
    }

    private void SetColorActive(ObjectColor color)
    {
        foreach (var obj in colorObjects)
        {
            if (obj.Data.ObjectColor == color)
                obj.SetActive();
            else
                obj.SetInactive();
        }

        ActiveColor = color;
    }
    
    public void AddObject(ColorObject obj)
    {
        colorObjects.Add(obj);
    }

    public void RemoveObject(ColorObject obj)
    {
        colorObjects.Remove(obj);
    }
}

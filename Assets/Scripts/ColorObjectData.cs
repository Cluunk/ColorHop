using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorObjectData", menuName = "ScriptableObjects/ColorObjectData")]
public class ColorObjectData : ScriptableObject
{
    [field:SerializeField] public ObjectColor ObjectColor { get; private set; }
    [field:SerializeField] public Color ActiveColor { get; private set; }
    [field:SerializeField] public Color InactiveColor { get; private set; }
}

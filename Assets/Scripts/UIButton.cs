using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioObject clickSound;
    [SerializeField] private AudioObject hoverSound;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!hoverSound)
            return;
        Instantiate(hoverSound);
    }

    public void Click()
    {
        Instantiate(clickSound);
    }
}

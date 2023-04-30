using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Lean;
using Lean.Transition;

public class DragButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public UnityEvent Down, Up;
    public LeanPlayer UpTransition;
    public LeanPlayer DownTransition;
    

    public void OnPointerUp(PointerEventData eventData)
    {
      ///  visual.color = prevColor;
        if (Up != null)
        {
            Up.Invoke();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
     ///   visual.color = colorChange;
        if (Down != null)
        {
            Down.Invoke();
        }
    }
}

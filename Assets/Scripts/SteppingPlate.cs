using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SteppingPlate : MonoBehaviour, Iinteractable
{
    // Start is called before the first frame update
    public elementTag[] interactionMask;
    public UnityEvent OnStepped, OnReleased;
    public animationcontroller animController;
    private int stepped = 0;
    public string objectName;
    private void Awake()
    {
        animController.uptodate(objectName);
    }

    private void Update()
    {
        if(stepped > 0)
            animController.PlayAnimation("Step");
        else
            animController.PlayAnimation("Release");
    }

    public void interaction(PlayersController player, elementTag elTag)
    {
        for (int i = 0; i < interactionMask.Length; i++)
        {
            if (interactionMask[i] == elTag)
            {
                OnStepped.Invoke();
                stepped += 1;
                break;
            }
        }
    }

    public void reverseInteraction(PlayersController player, elementTag elTag)
    {
        for (int i = 0; i < interactionMask.Length; i++)
        {
            if (interactionMask[i] == elTag)
            {
                stepped -= 1;
                if (stepped <= 0)
                {
                    OnReleased.Invoke();
                    stepped = 0;
                }
                break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destination : MonoBehaviour, Iinteractable
{
    public elementTag interactionMask;
    public UnityEvent OnReached, OnNotReached;

    public void interaction(PlayersController player, elementTag elTag)
    {
        if (interactionMask == elTag)
        {
            LevelManager.instance.setPlayerReached(elTag, true);
            OnReached.Invoke();
        }
    }

    public void reverseInteraction(PlayersController player, elementTag elTag)
    {
        if (interactionMask == elTag)
        {
            LevelManager.instance.setPlayerReached(elTag, false);
            OnNotReached.Invoke();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour, Iinteractable
{
    public elementTag[] interactionMask;
    public int addingScore = 1;
    public animationcontroller animController;
    public string objectIndex;
    private void Start()
    {
        animController.uptodate(objectIndex);
        StartCoroutine(check());
    }

    IEnumerator check()
    {
        animController.PlayAnimation("Cycle");
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        StartCoroutine(check());
    }
    public void interaction(PlayersController player, elementTag elTag)
    {
        for (int i = 0; i < interactionMask.Length; i++)
        {
            if (interactionMask[i] == elTag)
            {
                LevelManager.instance.score(elTag, addingScore);
                animController.playTransition("Destroy", () => gameObject.SetActive(false));
                break;
            }
        }
    }

    public void reverseInteraction(PlayersController player, elementTag elTag)
    {
        
    }
}

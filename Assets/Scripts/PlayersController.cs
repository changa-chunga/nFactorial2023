using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour
{
    public elementTag myTag;
    public string playerIndex;
    public animationcontroller animController;
    private void Start()
    {
        animController.uptodate(playerIndex);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Component interactable;
        if(col.TryGetComponent(typeof(Iinteractable), out interactable) == true)
        {
            (interactable as Iinteractable).interaction(this, myTag);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        Component interactable;
        if(col.TryGetComponent(typeof(Iinteractable), out interactable) == true)
        {
            (interactable as Iinteractable).reverseInteraction(this, myTag);
        }
    }

    public void Die()
    {
        animController.playTransition("Die", ()=> LevelManager.instance.GameOver());
    }
}
public enum elementTag{
    fire,
    water
}
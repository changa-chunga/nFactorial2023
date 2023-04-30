using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour, Iinteractable
{
    public elementTag[] interactionMask;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interaction(PlayersController player, elementTag elTag)
    {
        for (int i = 0; i < interactionMask.Length; i++)
        {
            if (interactionMask[i] == elTag)
            {
                player.Die();
                break;
            }
        }
    }

    public void reverseInteraction(PlayersController player, elementTag elTag)
    {
        
    }
}

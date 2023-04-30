using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatedDecoration : MonoBehaviour
{
    public string objectIndex;
    public animationcontroller animController;
    public bool constantlyPlayAnimation;
    public string constantAnimationName;
    private bool playing = false;

    private void OnEnable()
    {
        animController.uptodate(objectIndex);
        if (constantlyPlayAnimation && playing == false)
            animationLoop();
    }

    private void animationLoop()
    {
        if (this.enabled)
        {
            playing = true;
            animController.PlayAnimation(constantAnimationName, animationLoop);
        }
        else
        {

            playing = false;
        }
    }
}

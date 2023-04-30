using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class animationcontroller : MonoBehaviour
{
    public string[] availableAnimations;
    [SerializeField]private AnimationSet[] animations;
    public SpriteRenderer[] subRenderers;
    Sprite original_sprite;
    private bool[] initialFlip;
    private bool animPlays;
    [Space] public Animation animComp;
    public TransitionSet[] availableTransitions;
    private bool transitionPlays;
    public string[] availableClips;

    public void uptodate(string objectName)
    {
        original_sprite = sprite_container.instance.GetDefaultSprite(objectName);
        initialFlip = new bool[subRenderers.Length];
        for (int i = 0; i < subRenderers.Length; i++)
        {
            subRenderers[i].sprite = original_sprite;
            initialFlip[i] = subRenderers[i].flipX;
        }

        animations = new AnimationSet[availableAnimations.Length];
        animComp = GetComponent<Animation>();
        for (int i = 0; i < availableAnimations.Length; i++)
        {
            animations[i] = sprite_container.instance.request(objectName, availableAnimations[i]);
        }

    }

    public void setForward()
    {
        for (int i = 0; i < subRenderers.Length; i++)
        {
            subRenderers[i].flipX = initialFlip[i];
        }
    }

    public void setBackward()
    {
        for (int i = 0; i < subRenderers.Length; i++)
        {
            subRenderers[i].flipX = !initialFlip[i];
        }
    }
    public void PlayAnimation(string animName)
    {

        for (int i = 0; i < availableClips.Length; i++)
        {
            if (availableClips[i] != animName) continue;
            if (animComp.GetClip(animName) == null) return;
            
            if(animComp.isPlaying == false)
                animComp.Play(animName);

            return;
        }

        if (animPlays == true)
            return;
        StartCoroutine(playAnimation(animName));
        
    }
    public void PlayAnimation(string animName, Action result)
    {
        for (int i = 0; i < availableClips.Length; i++)
        {
            if (availableClips[i] != animName) continue;
            
            if (animComp.GetClip(animName) != null)
            {
                if(animComp.isPlaying == false)
                    animComp.Play(animName);
            }

            return;
        }

        if (animPlays == true)
            return;
        StartCoroutine(playAnimation(animName, result));
        
    }
    private IEnumerator playAnimation(string animationName)
    {
        if (animPlays != false) yield break;
        for (int i = 0; i < availableAnimations.Length; i++)
        {
            if (availableAnimations[i] != animationName) continue;
            animPlays = true;
            for (int j = 0; j < animations[i].frames.Length; j++)
            {
                for (int k = 0; k < subRenderers.Length; k++)
                {
                    subRenderers[k].sprite = animations[i].frames[j].sprite;
                }
                        
                for (int fr = 0; fr < animations[i].frames[j].frameTime; fr++)
                {
                    yield return null;
                }
            }
            for (int j = 0; j < subRenderers.Length; j++)
            {
                subRenderers[j].sprite = original_sprite;
            }

            animPlays = false;
            yield break;
        }
        yield break;
    }
    private IEnumerator playAnimation(string animationName, Action result)
    {
        if (animPlays != false) yield break;
        for (int i = 0; i < availableAnimations.Length; i++)
        {
            if (availableAnimations[i] != animationName) continue;
            animPlays = true;
            for (int j = 0; j < animations[i].frames.Length; j++)
            {
                for (int k = 0; k < subRenderers.Length; k++)
                {
                    subRenderers[k].sprite = animations[i].frames[j].sprite;
                }
                        
                for (int fr = 0; fr < animations[i].frames[j].frameTime; fr++)
                {
                    yield return null;
                }
            }
            for (int k = 0; k < subRenderers.Length; k++)
            {
                subRenderers[k].sprite = original_sprite;
            }

            animPlays = false;
            result.Invoke();
            yield break;
        }
        yield break;
    }
    public void playTransition(string trName)
    {
        if (transitionPlays == true)
            return;
        for (int f = 0; f < availableTransitions.Length; f++)
        {
            if (availableTransitions[f].index != trName) continue;
            
            availableTransitions[f].transitions.Begin();
            StartCoroutine(transitionDelay(availableTransitions[f].TransitionLength));
            break;
        }
    }
    public void playTransition(string trName, Action ToInvoke)
    {
        if (transitionPlays == true)
            return;
        for (int f = 0; f < availableTransitions.Length; f++)
        {
            if (availableTransitions[f].index != trName) continue;
            
            availableTransitions[f].transitions.Begin();
            StartCoroutine(transitionDelay(availableTransitions[f].TransitionLength, ToInvoke));
            break;
        }
    }
    IEnumerator transitionDelay(float time)
    {
        transitionPlays = true;
        yield return new WaitForSeconds(time);
        transitionPlays = false;
    }
    IEnumerator transitionDelay(float time, Action toInvoke)
    {
        transitionPlays = true;
        yield return new WaitForSeconds(time);
        transitionPlays = false;
        toInvoke.Invoke();
    }
}

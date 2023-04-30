using UnityEngine;
using System;
using Lean.Transition;

[System.Serializable]
public struct KeyFrame
{
    public Sprite sprite;
    public int frameTime;
}
[System.Serializable]
public struct AnimationSet
{
    public string animName;
    public KeyFrame[] frames;
}
[System.Serializable]
public class TransitionSet
{
    public string index;
    public LeanPlayer transitions;
    [Tooltip("In Seconds")]
    public float TransitionLength;
}
[System.Serializable]
public struct audioSet
{
    public int level;
    public bool isAlly;
    public AudioClip clip;
    public float volume;
    public int maxAllowedSources;
    [HideInInspector]
    public AudioSource[] sources;
    [HideInInspector]
    public int currentSource;
}
[System.Serializable]
public struct AudioForObject
{
    public string index;
    public audioSet[] audios;
}

public interface Iinteractable
{
    public void interaction(PlayersController player, elementTag elTag);
    public void reverseInteraction(PlayersController player, elementTag elTag);
}

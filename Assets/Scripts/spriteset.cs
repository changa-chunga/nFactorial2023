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

public interface Iinteractable
{
    public void interaction(PlayersController player, elementTag elTag);
    public void reverseInteraction(PlayersController player, elementTag elTag);
}

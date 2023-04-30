using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using Lean.Transition;
public class DoubleSideClickTransition : MonoBehaviour
{
    [SerializeField]
    LeanPlayer StartTransition;
    [SerializeField]
    LeanPlayer ReverseTransition;


    [HideInInspector]
    public ref LeanPlayer ForwardTransition { get { return ref StartTransition; } }
    [HideInInspector]
    public ref LeanPlayer BackwardTransition { get { return ref ReverseTransition; } }

    public void StartForwardTransition()
    {
        ForwardTransition.Begin();
    }
    public void StartReverseTransition()
    {
        BackwardTransition.Begin();
    }

}
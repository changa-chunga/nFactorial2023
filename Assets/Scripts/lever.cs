using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class lever : MonoBehaviour
{
    public int rightActionActivationAngle;
    public int leftActionActivationAngle;
    public UnityEvent rightAction, leftAction;
    private bool isRight = true;
    private bool firstTime = true;
    public Rigidbody2D rb;
    public Collider2D myCol;

    private void Start()
    {
        StartCoroutine(check());
    }
    
    private IEnumerator check()
    {
        if (isRight == false)
        {
            if (rb.rotation <= rightActionActivationAngle)
            {
                firstTime = false;
                isRight = true;
                rightAction.Invoke();
                myCol.isTrigger = true;
            }
        }
        else if (firstTime)
        {
            if (rb.rotation <= rightActionActivationAngle)
            {
                firstTime = false;
                isRight = true;
                rightAction.Invoke();
                myCol.isTrigger = true;
            }
            else if (rb.rotation >= leftActionActivationAngle)
            {
                firstTime = false;
                isRight = false;
                leftAction.Invoke();
                myCol.isTrigger = true;
            }
        }
        else
        {
            if (rb.rotation >= leftActionActivationAngle)
            {
                firstTime = false;
                isRight = false;
                leftAction.Invoke();
                myCol.isTrigger = true;
            }
        }

        yield return null;
        yield return null;
        yield return null;
        yield return null;
        StartCoroutine(check());
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        myCol.isTrigger = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    { 
        myCol.isTrigger = false;
    }
}

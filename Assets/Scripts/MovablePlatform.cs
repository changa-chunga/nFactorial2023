using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2[] Points;
    public Rigidbody2D rb;
    public AnimationCurve interpolation;
    public float speed;
    public void moveToPoint(int index)
    {
        StopAllCoroutines();
        StartCoroutine(moveToPointRoutine(index));
    }

    IEnumerator moveToPointRoutine(int index)
    {
        Vector2 initialPos = rb.position;
        Vector2 diff = Points[index] - initialPos;
        float time = diff.magnitude / speed;
        for (int t = 0; t <= time; t++)
        {
            rb.MovePosition(initialPos + (diff * interpolation.Evaluate(t / time)));
            yield return new WaitForFixedUpdate();
        }
    }
}

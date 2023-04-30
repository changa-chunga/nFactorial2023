using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersInputController : MonoBehaviour
{
    public PlayersController myPlController;
    public string inputName;
    public string jumpInputName;
    public Rigidbody2D rb;
    public Collider2D coll;
    public bool onGround;
    public float speed;
    public float jumpForce;

    private void Start()
    {
        StartCoroutine(checkGround());
    }

    private float fbAxis;
    void Update()
    {
        if (LevelManager.instance.paused)
            return;
        fbAxis = Input.GetAxisRaw(inputName);
        if (fbAxis > 0)
        {
            fbAxis *= speed;
            myPlController.animController.PlayAnimation("Walk");
            myPlController.animController.setForward();
        }
        else if (fbAxis < 0)
        {
            fbAxis *= speed;
            myPlController.animController.PlayAnimation("Walk");
            myPlController.animController.setBackward();
        }
        rb.velocity = new Vector2(fbAxis, rb.velocity.y);
        if (Input.GetButtonDown(jumpInputName))
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (onGround == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            onGround = false;
        }
    }

    IEnumerator checkGround()
    {
        if (Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, 1 << 6))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        StartCoroutine(checkGround());
    }
}

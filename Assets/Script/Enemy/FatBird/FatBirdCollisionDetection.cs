using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FatBirdCollisionDetection : MonoBehaviour
{
    private FatBirdMoving fatBirdMoving;
    private Rigidbody2D rb;
    private bool isTouch = false;
    private bool isGrounded = false;

    private void Start()
    {
        rb = this.transform.parent.GetChild(0).GetComponent<Rigidbody2D>();
        fatBirdMoving = this.transform.parent.GetChild(0).GetComponent<FatBirdMoving>();
    }

    private void Update()
    {
        isGrounded = fatBirdMoving.GetIsGrounded();
    }
    public bool GetIsTouch()
    {
        return this.isTouch;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.gravityScale = 1f;
            isTouch = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.gravityScale = 0f;
            isTouch = false;
            fatBirdMoving.SetIsFly(true);
        }
    }
}

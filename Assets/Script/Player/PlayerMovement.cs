using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    [SerializeField] private LayerMask jumpableGround;
    private float dirX;
    private int jumps = 0;
    private bool isDoubleJump = false;
    [SerializeField] private const int maxJumps = 2;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private PlayerSound playerSound;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public bool GetIsDoubleJump()
    {
        return this.isDoubleJump;
    }

    private void Move()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        Flip();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                playerSound.PlayJumpSound();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumps = 1;
                isDoubleJump = false;
            }
            else if (jumps < maxJumps)
            {
                playerSound.PlayJumpSound();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumps++;
                isDoubleJump = true;
            }
        }
    }

    private void Update()
    {
        if (IsGrounded() || rb.velocity.y < -0.01f)
        {
            isDoubleJump = false;
        }

        Move();
        Jump();
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    //private void Flip()
    //{
    //    if (isFacingRight && dirX < 0f || !isFacingRight && dirX > 0f)
    //    {
    //        isFacingRight = !isFacingRight;
    //        Vector3 localScale = transform.localScale;
    //        localScale.x *= -1f;
    //        transform.localScale = localScale;
    //    }
    //}

    private void Flip()
    {
        if (dirX < 0)
        {
            sprite.flipX = true;
        }
        else if (dirX > 0) {
            sprite.flipX = false;
        } 
    }
}
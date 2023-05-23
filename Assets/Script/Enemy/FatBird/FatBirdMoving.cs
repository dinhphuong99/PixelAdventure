using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBirdMoving : MonoBehaviour
{
    [SerializeField] private GameObject waypoints;
    private Rigidbody2D rb;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float speed = 2f;
    private bool isGrounded = false;
    private bool isFly = false;

    public void SetIsFly(bool isFly)
    {
        this.isFly = isFly;
    }

    public bool GetIsGrounded()
    {
        return this.isGrounded;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = IsGrounded();

        if (isFly && Vector2.Distance(waypoints.transform.position, transform.position) > 0f)
        {
            rb.gravityScale = 0f;
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints.transform.position, Time.deltaTime * speed);
        }

        if (Vector2.Distance(waypoints.transform.position, transform.position) == 0f )
        {
            isFly = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -transform.up, 0.5f, jumpableGround);
    }

    private void Flying()
    {
        rb.gravityScale = 0f;
        isFly = true;
    }
}
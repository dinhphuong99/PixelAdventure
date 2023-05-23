using System.Collections;
using UnityEngine;

public class WallClimbSlide : MonoBehaviour
{
    [SerializeField] private LayerMask jumpableGround;
    private bool isTouchingWall; // Trạng thái đang leo tường
    private bool isTouchGrounded;
    private bool JumpOff = false;
    private BoxCollider2D coll;
    public float wallSlideSpeed = 2f;
    public float wallClimbSpeed = 6f;
    private Rigidbody2D rb;  //Rigidbody2D của nhân vật
    [SerializeField] private float wallcheckDistance = 0.5f;
    [SerializeField] private LayerMask wallLayer;
    // Xác định xem nhân vật đã chạm tường nhưng chưa chạm đất hoặc chưa chạm
    // vào bất kỳ đối tượng nào

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (!isTouchingWall)
        {
            rb.gravityScale = 1f;
        }

        isTouchGrounded = IsGrounded();
        if (!isTouchGrounded)
        {
            // Check if the player is touching the wall
            if (Physics2D.Raycast(transform.position, transform.right, wallcheckDistance, wallLayer))
            {
                isTouchingWall = true;
            }
            else if (Physics2D.Raycast(transform.position, -transform.right, wallcheckDistance, wallLayer))
            {
                isTouchingWall = true;
            }
            else
            {
                isTouchingWall = false;

            };
        }
        else
        {
            isTouchingWall = false;

        };

        WallClimb(isTouchingWall, isTouchGrounded);
    }

    private void WallClimb(bool isTouchingWall, bool isTouchGrounded)
    {

        if (isTouchGrounded)
        {
            JumpOff = false;
            return;
        };

        if (isTouchingWall)
        {
            if (Input.GetButton("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, wallClimbSpeed);
                rb.gravityScale = 0f;
                JumpOff = true;
            }
            else
            {
                WallSlide();
                JumpOff = false;
            }
            return;
        };

        if (JumpOff)
        {
            rb.velocity = new Vector2(rb.velocity.x, 7f);
            rb.gravityScale = 1f;
            JumpOff = false;
            return;
        }
    }

    private void WallSlide()
    {
        rb.gravityScale = 1f;
        rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    public bool GetIsTouchingWall()
    {
        return this.isTouchingWall;
    }
}
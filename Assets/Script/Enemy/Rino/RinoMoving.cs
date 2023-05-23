using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoMoving : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 4f;
    [SerializeField] private LayerMask jumpableGround;
    private RinoCollisionDetection rinoCollisionDetection;
    private SpriteRenderer sprite;
    private bool isWaiting = false;
    private bool isTouchWall = false;

    public int GetCurrentWaypointIndex()
    {
        return this.currentWaypointIndex;
    }

    public bool GetIsWaiting()
    {
        return this.isWaiting;
    }

    public bool GetIsTouchWall()
    {
        return this.isTouchWall;
    }

    private void Start()
    {
        rinoCollisionDetection = this.transform.parent.GetChild(1).GetComponent<RinoCollisionDetection>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTouchWall();
        if (!isWaiting && Vector2.Distance(waypoints[currentWaypointIndex].transform.position,
            transform.position) < 0.01f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }

            isWaiting = true;
        }

        if (isWaiting && rinoCollisionDetection.GetIsTouch())
        {
            isWaiting = false;
        }

        if (!isWaiting)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
    }

    private void CheckTouchWall()
    {
        if (!sprite.flipX && Physics2D.Raycast(transform.position, -transform.right, 0.5f, jumpableGround))
        {
            this.isTouchWall = true;
        }

        if (sprite.flipX && Physics2D.Raycast(transform.position, transform.right, 0.5f, jumpableGround))
        {
            this.isTouchWall = true;
        }
    }

    private void TouchWallDone()
    {
        this.isTouchWall = false;
        sprite.flipX = !sprite.flipX;
    }
}
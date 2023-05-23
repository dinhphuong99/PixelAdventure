using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHitSpikeHead : MonoBehaviour
{
    [SerializeField] private float checkTouchWall = 0.4f;
    [SerializeField] private float checkTouchPositionWall = 0.6f;
    [SerializeField] private LayerMask wallLayer;
    private int currentWaypointIndex = -1;
    private SpikeHead spikeHead;

    void Start()
    {
        spikeHead = GetComponent<SpikeHead>();
    }

    //Touch Wall
    private bool checkTouchingLeftWall = false;

    public bool GetCheckTouchingLeftWall()
    {
        return this.checkTouchingLeftWall;
    }

    private bool checkTouchingRightWall = false;

    public bool GetCheckTouchingRightWall()
    {
        return this.checkTouchingRightWall;
    }
    private bool checkTouchingTopWall = false;

    public bool GetCheckTouchingTopWall()
    {
        return this.checkTouchingTopWall;
    }

    private bool checkTouchingBottomWall = false;

    public bool GetCheckTouchingBottomWall()
    {
        return this.checkTouchingBottomWall;
    }

    private void Update()
    {
        this.currentWaypointIndex = spikeHead.GetCurrentWaypointIndex();
        WallHit();
    }

    private void WallHit()
    {

        checkTouchingRightWall = (this.currentWaypointIndex == 0 && Physics2D.Raycast(transform.position, transform.right, checkTouchWall, wallLayer)
            && !Physics2D.Raycast(transform.position, -transform.right, checkTouchPositionWall, wallLayer));

        checkTouchingLeftWall = (this.currentWaypointIndex == 2 && Physics2D.Raycast(transform.position, -transform.right, checkTouchWall, wallLayer)
            && !Physics2D.Raycast(transform.position, transform.right, checkTouchPositionWall, wallLayer));

        checkTouchingTopWall = (this.currentWaypointIndex == 1 && Physics2D.Raycast(transform.position, transform.up, checkTouchWall, wallLayer)
            && !Physics2D.Raycast(transform.position, -transform.up, checkTouchPositionWall, wallLayer));

        checkTouchingBottomWall = (this.currentWaypointIndex == 3 && Physics2D.Raycast(transform.position, -transform.up, checkTouchWall, wallLayer)
            && !Physics2D.Raycast(transform.position, transform.up, checkTouchPositionWall, wallLayer));
    }
}
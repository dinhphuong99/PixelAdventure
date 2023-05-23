using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHitAndCheckWall : MonoBehaviour
{
    [SerializeField] private float checkTouchWall = 0.4f;
    [SerializeField] private float checkTouchPositionWall = 0.6f;
    [SerializeField] private float topBottomWall = 1.15f;
    [SerializeField] private float leftRightWall = 0.89f;
    [SerializeField] private LayerMask wallLayer;
    private int currentWaypointIndex = -1;
    private RockHead rockHead;

    void Start()
    {
        rockHead = GetComponent<RockHead>();
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

    //Check Wall
    private bool checkLeftWall = false;

    public bool GetCheckLeftWall()
    {
        return this.checkLeftWall;
    }

    private bool checkRightWall = false;

    public bool GetCheckRightWall()
    {
        return this.checkRightWall;
    }

    private bool checkTopWall = false;

    public bool GetCheckTopWall()
    {
        return this.checkTopWall;
    }

    private bool checkBottomWall = false;

    public bool GetCheckBottomWall()
    {
        return this.checkBottomWall;
    }

    private void Update()
    {
        this.currentWaypointIndex = rockHead.GetCurrentWaypointIndex();
        WallHit();
        CheckWall();
    }

    private void CheckWall()
    {
        checkRightWall = this.currentWaypointIndex == 0 && Physics2D.Raycast(transform.position, transform.right, leftRightWall, wallLayer);
        checkLeftWall = this.currentWaypointIndex == 2 && Physics2D.Raycast(transform.position, -transform.right, leftRightWall, wallLayer);
        checkTopWall = this.currentWaypointIndex == 1 && Physics2D.Raycast(transform.position, transform.up, topBottomWall, wallLayer);
        checkBottomWall = this.currentWaypointIndex == 3 && Physics2D.Raycast(transform.position, -transform.up, topBottomWall, wallLayer);
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
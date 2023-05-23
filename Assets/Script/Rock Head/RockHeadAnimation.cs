using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RockHeadAnimation : MonoBehaviour
{
    private Animator anim;
    private WallHitAndCheckWall wallHitAndCheckWall;
    private string currentState;
    private bool leftRightHit = false;
    private bool topBottomHit = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        wallHitAndCheckWall = GetComponent<WallHitAndCheckWall>();
        currentState = "Blink";
    }

    private void Update()
    {

        if (wallHitAndCheckWall.GetCheckTouchingBottomWall() || wallHitAndCheckWall.GetCheckTouchingTopWall())
        {
            topBottomHit = true;
        }
        else
        {
            topBottomHit = false;
        }

        if (wallHitAndCheckWall.GetCheckTouchingLeftWall() || wallHitAndCheckWall.GetCheckTouchingRightWall())
        {
            leftRightHit = true;
        }
        else
        {
            leftRightHit = false;
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
       
        if (topBottomHit)
        {
            ChangeAnimationState("BottomHit");
        }
        else if (leftRightHit)
        {
            ChangeAnimationState("LeftHit");
        }
        else
        {
            ChangeAnimationState("Blink");
        }
    }

    private void ChangeAnimationState(string newState)
    {
        if (anim == null)
        {
            Debug.LogError("Animator is not assigned!");
            return;
        }

        if (string.IsNullOrEmpty(newState))
        {
            Debug.LogError("New state is null or empty!");
            return;
        }

        if (!anim.HasState(0, Animator.StringToHash(newState)))
        {
            Debug.LogError("New state is not a valid animator state: " + newState);
            return;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName(newState))
        {
            return;
        }

        currentState = newState;
        anim.Play(currentState);
    }
}
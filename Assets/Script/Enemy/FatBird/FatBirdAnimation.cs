using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FatBirdAnimation : MonoBehaviour
{
    private Animator anim;
    private FatBirdMoving fatBirdMoving;
    private KillPointAndAttackPlayer killPointAndAttackPlayer;
    private bool isAttack = false;
    private bool isDeath = false;
    private bool isGrounded = false;
    private string currentState = "Idle";
    private Rigidbody2D rb;

    private void Start()
    {
        fatBirdMoving = GetComponent<FatBirdMoving>();
        killPointAndAttackPlayer = GetComponent<KillPointAndAttackPlayer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isAttack = killPointAndAttackPlayer.GetIsAttack();
        isDeath = killPointAndAttackPlayer.GetIsDeath();
        isGrounded = fatBirdMoving.GetIsGrounded();
        rb = GetComponent<Rigidbody2D>();

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (isDeath)
        {
            ChangeAnimationState("Die");
        }
        else if (isAttack)
        {
            ChangeAnimationState("Hit");
        }
        else if (isGrounded)
        {
            ChangeAnimationState("Ground");
        }
        else if (rb.gravityScale != 0f)
        {
            ChangeAnimationState("Fall");
        }
        else
        {
            ChangeAnimationState("Idle");
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
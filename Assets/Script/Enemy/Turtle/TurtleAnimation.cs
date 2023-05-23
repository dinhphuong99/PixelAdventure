using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class TurtleAnimation : MonoBehaviour
{
    private Animator anim;
    private TurtleBehaviour turtleBehaviour;
    private KillPointAndAttackPlayer killPointAndAttackPlayer;
    private bool isAttack = false;
    private bool isDeath = false;
    private bool isSpikeOut = false;
    private bool isSpikeIn = true;
    private bool isSpikeInDone = false;
    private bool isSpikeOutDone = false;
    private string currentState = "Idle 2";

    private void Start()
    {
        turtleBehaviour = GetComponent<TurtleBehaviour>();
        killPointAndAttackPlayer = this.transform.GetChild(0).GetComponent<KillPointAndAttackPlayer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isAttack = killPointAndAttackPlayer.GetIsAttack();
        isDeath = killPointAndAttackPlayer.GetIsDeath();
        isSpikeOut = turtleBehaviour.GetIsSpikeOut();
        isSpikeIn = turtleBehaviour.GetIsSpikeIn();
        isSpikeOutDone = turtleBehaviour.GetIsSpikeOutDone();
        isSpikeInDone = turtleBehaviour.GetIsSpikeInDone();
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
        else if (isSpikeInDone)
        {
            ChangeAnimationState("Idle 2");
        }
        else if (isSpikeIn)
        {
            ChangeAnimationState("Spikes in");
        }
        else if (isSpikeOutDone)
        {
            ChangeAnimationState("Idle 1");
        }
        else if (isSpikeOut)
        {
            ChangeAnimationState("Spikes out");
        }
        else
        {
            ChangeAnimationState("Idle 2");
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
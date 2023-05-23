using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimation : MonoBehaviour
{
    private Animator anim;
    private MovingWithWaitTime movingWithWaitTime;
    private KillPointAndAttackPlayerWithParticles killPointAndAttackPlayerWithParticles;
    private SpriteRenderer sprite;
    private int currentWaypointIndex = 0;
    private bool isAttack = false;
    private bool isDeath = false;
    private bool isWaiting = false;
    private string currentState = "Run";

    private void Start()
    {
        movingWithWaitTime = this.transform.GetComponent<MovingWithWaitTime>();
        killPointAndAttackPlayerWithParticles = this.transform.GetChild(0).GetComponent<KillPointAndAttackPlayerWithParticles>();
        currentWaypointIndex = movingWithWaitTime.GetCurrentWaypointIndex();
        isWaiting = movingWithWaitTime.GetIsWaiting();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentWaypointIndex = movingWithWaitTime.GetCurrentWaypointIndex();
        isAttack = killPointAndAttackPlayerWithParticles.GetIsAttack();
        isDeath = killPointAndAttackPlayerWithParticles.GetIsDeath();
        isWaiting = movingWithWaitTime.GetIsWaiting();
        
        if (currentWaypointIndex == 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (isAttack)
        {
            ChangeAnimationState("Hit");
        }
        else
        {
            ChangeAnimationState("Idle-Run");
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
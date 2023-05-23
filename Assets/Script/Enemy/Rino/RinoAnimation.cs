using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoAnimation : MonoBehaviour
{
    private Animator anim;
    private RinoMoving rinoMoving;
    private KillPointAndAttackPlayer killPointAndAttackPlayer;
    private SpriteRenderer sprite;
    private int currentWaypointIndex = 0;
    private bool isAttack = false;
    private bool isDeath = false;
    private bool isWaiting = false;
    private bool isTouchWall = false;
    private string currentState = "Run";

    private void Start()
    {
        rinoMoving = GetComponent<RinoMoving>();
        killPointAndAttackPlayer = GetComponent<KillPointAndAttackPlayer>();
        currentWaypointIndex = rinoMoving.GetCurrentWaypointIndex();
        isWaiting = rinoMoving.GetIsWaiting();
        isTouchWall = rinoMoving.GetIsTouchWall();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentWaypointIndex = rinoMoving.GetCurrentWaypointIndex();
        isAttack = killPointAndAttackPlayer.GetIsAttack();
        isDeath = killPointAndAttackPlayer.GetIsDeath();
        isWaiting = rinoMoving.GetIsWaiting();
        isTouchWall = rinoMoving.GetIsTouchWall();

        if (!isTouchWall)
        {
            if (currentWaypointIndex == 0)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (isDeath)
        {
            ChangeAnimationState("Die");
        }
        else if (isTouchWall)
        {
            ChangeAnimationState("Hit Wall");
        }
        else if (isAttack)
        {
            ChangeAnimationState("Hit");
        }
        else if (isWaiting)
        {
            ChangeAnimationState("Idle");
        }
        else
        {
            ChangeAnimationState("Run");
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
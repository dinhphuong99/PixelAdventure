using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryPigAnimation : MonoBehaviour
{
    private Animator anim;
    private MovingWithSpeedUp movingWithSpeedUp;
    private CollisionDetection collisionDetection;
    private KillPointAndAttackPlayer killPointAndAttackPlayer;
    private Vector3 localScale;
    private int currentWaypointIndex = 0;
    private bool isAttack = false;
    private bool isDeath = false;
    private bool isWaiting = false;
    private bool isSpeedUp = false;
    private string currentState = "Walk";

    private void Start()
    {
        movingWithSpeedUp = GetComponent<MovingWithSpeedUp>();
        killPointAndAttackPlayer = this.transform.GetChild(0).GetComponent<KillPointAndAttackPlayer>();
        collisionDetection = this.transform.GetChild(2).GetComponent<CollisionDetection>();
        currentWaypointIndex = movingWithSpeedUp.GetCurrentWaypointIndex();
        isWaiting = movingWithSpeedUp.GetIsWaiting();
        isSpeedUp = movingWithSpeedUp.GetIsSpeedUp();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentWaypointIndex = movingWithSpeedUp.GetCurrentWaypointIndex();
        isAttack = killPointAndAttackPlayer.GetIsAttack();
        isDeath = killPointAndAttackPlayer.GetIsDeath();
        isWaiting = movingWithSpeedUp.GetIsWaiting();
        isSpeedUp = movingWithSpeedUp.GetIsSpeedUp();
        

        if (currentWaypointIndex == 0)
        {
            localScale = this.transform.localScale;
            localScale.x = 1f;
            this.transform.localScale = localScale;
        }
        else
        {
            localScale = this.transform.localScale;
            localScale.x = -1f;
            this.transform.localScale = localScale;
        }

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
        else if (isSpeedUp)
        {
            ChangeAnimationState("Run");
        }
        else if (isWaiting)
        {
            ChangeAnimationState("Idle");
        }
        else
        {
            ChangeAnimationState("Walk");
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
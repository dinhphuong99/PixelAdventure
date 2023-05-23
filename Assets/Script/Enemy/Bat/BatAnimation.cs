using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private BatBehaviour batBehaviour;
    private BatKillPoint batKillPoint;
    private Vector3 localScale;
    private bool isAttack = false;
    private bool isDeath = false;
    private float previousPositionX = 0f;
    private bool isCellingOut = false;
    private bool isCellingIn = false;
    private bool isFlying = false;
    private string currentState = "Run";
    [SerializeField] private float waitingTime = 0.5f;
    private float waitingTimer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        batBehaviour = GetComponent<BatBehaviour>();
        batKillPoint = this.transform.GetChild(0).GetComponent<BatKillPoint>();
        anim = GetComponent<Animator>();
        previousPositionX = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        isAttack = batKillPoint.GetIsAttack();
        isDeath = batKillPoint.GetIsDeath();
        isFlying = batBehaviour.GetIsFlying();
        isCellingOut = batBehaviour.GetIsCellingOut();
        isCellingIn = batBehaviour.GetIsCellingIn();

        waitingTimer += Time.deltaTime;
        if (waitingTimer >= waitingTime)
        {
            if (this.transform.position.x - previousPositionX <= 0)
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
            waitingTimer = 0f;
        }

        previousPositionX = this.transform.position.x;

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
        else if (isCellingOut)
        {
            ChangeAnimationState("Ceiling Out");
        }
        else if (isCellingIn)
        {
            ChangeAnimationState("Ceiling In");
        }
        else if (isFlying)
        {
            ChangeAnimationState("Flying");
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
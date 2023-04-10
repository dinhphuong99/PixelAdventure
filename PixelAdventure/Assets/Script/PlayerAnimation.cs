using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private bool isDead = false;
    private bool isRevival;
    private WallClimbSlide wallClimbSlide;
    private PlayerMovement playerMovement;

    private int currentCharacter = 0;

    private enum AllCharacterState { Player_Revival, Player_Death }

    private ArrayList characterState = new ArrayList();

    private void AddCharacterState()
    {
        string[] virtualGuyState = new string[] {
            // Virtual Guy
            "Player_Idle", "Player_Falling", "Player_Jumping", "Player_Running", "Player_Wall", "Player_DoubleJump"
        };

        characterState.Add(virtualGuyState);

        string[] pinkManState = new string[] {
            //Pink Man
            "PlayerPM_Idle", "PlayerPM_Falling", "PlayerPM_Jumping", "PlayerPM_Running", "PlayerPM_Wall", "PlayerPM_DoubleJump"
        };

        characterState.Add(pinkManState);

        string[] ninjaFrogState = new string[] {
            // Ninja Frog
            "PlayerNF_Idle", "PlayerNF_Falling", "PlayerNF_Jumping", "PlayerNF_Running", "PlayerNF_Wall", "PlayerNF_DoubleJump"
        };

        characterState.Add(ninjaFrogState);

        string[] maskDudeState = new string[] {
            // Mask Dude
            "PlayerMD_Idle", "PlayerMD_Falling", "PlayerMD_Jumping", "PlayerMD_Running", "PlayerMD_Wall", "PlayerMD_DoubleJump"
        };

        characterState.Add(maskDudeState);
    }

    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        wallClimbSlide = GetComponent<WallClimbSlide>();
        playerMovement = GetComponent<PlayerMovement>();
        isRevival = true;
        //string[] firstCharacterStates = (string[])characterState[0];
        //currentState = firstCharacterStates[0];
        currentCharacter = PlayerPrefs.GetInt("characterIndex");
        AddCharacterState();
        Debug.Log("currentCharacter" + currentCharacter);
        currentState = ((string[])characterState[0])[0];
    }

    public void SetDead(bool value)
    {
        isDead = value;
    }

    private void Update()
    {
        if (isRevival)
        {
            Revival();
        }else
            UpdateAnimationState();
    }

    private void Revival()
    {
        rb.bodyType = RigidbodyType2D.Static;
        ChangeAnimationState(AllCharacterState.Player_Revival.ToString());
    }

    private void UpdateIsRevival()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        isRevival = false;
    }

    private void UpdateAnimationState()
    {
        if (isRevival)
        {
            Debug.Log("isRevival " + isRevival);
            ChangeAnimationState(AllCharacterState.Player_Revival.ToString());
            isRevival = false;
        }
        else if (isDead)
        {
            ChangeAnimationState(AllCharacterState.Player_Death.ToString());
        }
        else if (wallClimbSlide.GetIsTouchingWall())
        {
            ChangeAnimationState(((string[])characterState[currentCharacter])[4]);
        }
        else if (playerMovement.GetIsDoubleJump())
        {
            ChangeAnimationState(((string[])characterState[currentCharacter])[5]);
        }
        else if (rb.velocity.y > 0.01f)
        {
            ChangeAnimationState(((string[])characterState[currentCharacter])[2]);
        }
        else if (rb.velocity.y < -0.01f)
        {
            ChangeAnimationState(((string[])characterState[currentCharacter])[1]);
        }
        else if (Mathf.Abs(rb.velocity.x) > 0)
        {
            ChangeAnimationState(((string[])characterState[currentCharacter])[3]);
        }
        else
        {
            ChangeAnimationState(((string[])characterState[currentCharacter])[0]);
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
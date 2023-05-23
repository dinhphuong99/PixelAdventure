using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Animator anim;
    private string currentState;
    private bool isFlame = false;
    private float flameTime = 20f;
    private float flameTimer = 0f;
    private GameObject flame;
    private float lastTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ChangeAnimationState("Off");
        flame = this.transform.GetChild(0).gameObject;
        isFlame = false;
        lastTime = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        if (isFlame)
        {
            float currentTime = Time.realtimeSinceStartup;
            float elapsedTime = currentTime - lastTime;
            lastTime = currentTime;

            flameTimer += elapsedTime;
            if (flameTimer >= flameTime)
            {
                isFlame = false;
                flame.SetActive(false);
                ChangeAnimationState("Off");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFlame)
        {
            ChangeAnimationState("Hit");
        }
    }

    private void FireOn()
    {
        ChangeAnimationState("On");
        flame.SetActive(true);
        isFlame = true;
        flameTimer = 0f;
        lastTime = Time.realtimeSinceStartup;
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

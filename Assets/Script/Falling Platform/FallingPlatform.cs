using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 1f;
    private float destroyDelay = 2f;
    private float restartDelay = 5f;
    private Vector2 originalPosition;
    private Animator anim;
    private string currentState = "Falling_Flatform_On";
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        originalPosition = transform.position;
        anim = GetComponent<Animator>();
        ChangeAnimationState("Falling_Flatform_On");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        ChangeAnimationState("Falling_Flatform_Off");
        yield return new WaitForSeconds(destroyDelay);
        gameObject.SetActive(false);
        Invoke("Restart", restartDelay);
    }

    private void Restart()
    {
        gameObject.SetActive(true);
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = originalPosition;
        ChangeAnimationState("Falling_Flatform_On");
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
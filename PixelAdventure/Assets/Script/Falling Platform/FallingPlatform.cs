using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 1f;
    private float destroyDelay = 2f;
    private float restartDelay = 5f;
    private Vector2 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    [SerializeField] private Rigidbody2D rb;

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
        yield return new WaitForSeconds(destroyDelay);
        gameObject.SetActive(false);
        Invoke("Restart", restartDelay);
    }

    private void Restart()
    {
        gameObject.SetActive(true);
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = originalPosition;
    }
}
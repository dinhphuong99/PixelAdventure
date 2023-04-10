using UnityEngine;

public class LedgeController : MonoBehaviour
{
    [SerializeField] private float climbSpeed = 3f;
    [SerializeField] private float dropSpeed = 3f;

    private bool canClimb;
    private bool isClimbing;
    private Vector3 startPos;
    private float startY;

    private void Start()
    {
        startPos = transform.position;
        startY = startPos.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canClimb = false;
            isClimbing = false;
        }
    }

    private void Update()
    {
        if (canClimb && Input.GetKey(KeyCode.W) && !isClimbing)
        {
            StartClimbing();
        }
        else if (isClimbing)
        {
            ContinueClimbing();
        }

        if (isClimbing && Input.GetKey(KeyCode.S))
        {
            DropLedge();
        }
    }

    private void StartClimbing()
    {
        isClimbing = true;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
    }

    private void ContinueClimbing()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(0, verticalInput * climbSpeed * Time.deltaTime, 0));

        if (transform.position.y >= startPos.y + GetComponent<BoxCollider2D>().size.y / 2)
        {
            isClimbing = false;
        }
    }

    private void DropLedge()
    {
        isClimbing = false;
        transform.Translate(new Vector3(0, -1 * dropSpeed * Time.deltaTime, 0));
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
    }
}
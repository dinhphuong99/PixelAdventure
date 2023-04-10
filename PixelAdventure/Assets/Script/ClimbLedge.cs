using UnityEngine;

public class ClimbLedge : MonoBehaviour
{
    public LayerMask wallLayer;
    public float rayDistance = 0.5f;
    public float jumpForce = 5f;
    public float climbHeight = 2f;
    private bool canClimbLedge;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, wallLayer))
        {
            Vector3 targetPosition = hit.point + hit.normal * 0.5f + Vector3.up * climbHeight;
            if (!Physics.Raycast(targetPosition, Vector3.down, rayDistance, wallLayer))
            {
                canClimbLedge = true;
            }
        }

        if (canClimbLedge && Input.GetButtonDown("Jump"))
        {
            Vector3 targetPosition = transform.position + Vector3.up * climbHeight;
            transform.Translate(targetPosition - transform.position, Space.World);
        }
    }
}
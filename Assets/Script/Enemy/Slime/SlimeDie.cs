using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDie : MonoBehaviour
{
    private MovingWithWaitTime movingWithWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        movingWithWaitTime = GetComponent<MovingWithWaitTime>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PointKill"))
        {
            movingWithWaitTime.enabled = false;
        }
    }
}

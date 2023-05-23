using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryPigDie : MonoBehaviour
{
    private MovingWithSpeedUp movingWithSpeedUp;

    // Start is called before the first frame update
    void Start()
    {
        movingWithSpeedUp = this.transform.parent.GetComponent<MovingWithSpeedUp>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PointKill"))
        {
            movingWithSpeedUp.enabled = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private bool isTouch = false;

    public bool GetIsTouch()
    {
        return this.isTouch;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouch = false;
        }
    }
}
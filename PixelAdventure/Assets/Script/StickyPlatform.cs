using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class StickyPlatform : MonoBehaviour
//{
//    private PlayerMovement playerMovement;

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.name == "Player")
//        {
//            collision.gameObject.transform.SetParent(transform);
//        }
//    }

//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.gameObject.name == "Player")
//        {
//            collision.gameObject.transform.SetParent(null);
//        }
//    }

//    private void Update()
//    {
//        if (Input.GetButtonDown("Jump"))
//        {
//            // Code
//        }
//    }
//}

public class StickyPlatform : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
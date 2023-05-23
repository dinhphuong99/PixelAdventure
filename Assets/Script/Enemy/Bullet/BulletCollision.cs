using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private GameObject[] pieces;
    [SerializeField] private float timeDestroy = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.name == "Terrian")
        {
            this.transform.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.transform.gameObject.GetComponent<Collider2D>().enabled = false;

            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i].SetActive(true);
            }
            
            Invoke("DestroyBullet", timeDestroy);
        }
    }
    private void DestroyBullet()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i].SetActive(false);
        }
        DestroyObject(this.transform.gameObject);
    }
}
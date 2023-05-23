using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPoint : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isDeath = false;
    private Collider2D boxCollider;
    private PlayerLife playerLife;
    private bool isAttack = false;

    public bool GetIsAttack()
    {
        return this.isAttack;
    }

    public bool GetIsDeath()
    {
        return this.isDeath;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerLife = player.GetComponent<PlayerLife>();
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PointKill") && rb.velocity.y < -0.01f
            && !collision.gameObject.CompareTag("Player"))
        {
            isDeath = true;
            boxCollider.enabled = false;
        }
        else if (!collision.gameObject.CompareTag("PointKill")
            && collision.gameObject.CompareTag("Player") && isDeath == false)
        {
            isAttack = true;
            playerLife.TakeOneDamage();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isAttack = false;
        }
    }
}
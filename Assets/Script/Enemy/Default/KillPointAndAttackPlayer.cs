using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPointAndAttackPlayer : MonoBehaviour
{
    private PlayerLife playerLife;
    private GameObject body;
    private Rigidbody2D rb;
    private GameObject parentGameObject;
    private Collider2D boxCollider;
    private bool isAttack = false;
    private bool isDeath = false;
    private bool isDying = false;

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
        body = this.transform.gameObject;
        parentGameObject = this.transform.parent.gameObject;
        boxCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDying) return;

        if (collision.gameObject.CompareTag("PointKill")
            && rb.velocity.y < -0.01f
            && !collision.gameObject.CompareTag("Player"))
        {
            isDeath = true;
            Die();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            isAttack = true;
            playerLife.TakeOneDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDying) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            isAttack = true;
            playerLife.TakeOneDamage();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isDying) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            isAttack = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isDying) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            isAttack = false;
        }
    }

    private void Die()
    {
        isDying = true;
        boxCollider.enabled = false;
        StartCoroutine(WaitAndDisable());
    }

    private IEnumerator WaitAndDisable()
    {
        yield return new WaitForSeconds(0.7f);
        isDying = false;
        body.SetActive(false);
        parentGameObject.SetActive(false);
    }
}
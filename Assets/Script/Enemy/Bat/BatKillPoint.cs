using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatKillPoint : MonoBehaviour
{
    private PlayerLife playerLife;
    private GameObject body;
    private GameObject parentGameObject;
    private Collider2D boxCollider;
    private Rigidbody2D rb;
    private AIPath aIPath;
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
        body = this.transform.gameObject;
        parentGameObject = this.transform.parent.gameObject;
        boxCollider = GetComponent<Collider2D>();
        rb = player.GetComponent<Rigidbody2D>();
        aIPath = this.transform.parent.GetComponent<AIPath>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDying) return;

        if (collision.gameObject.CompareTag("PointKill") && rb.velocity.y < -0.01f
            && !collision.gameObject.CompareTag("Player"))
        {
            isDeath = true;
            boxCollider.enabled = false;
            Die();
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
        if (isDying) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            isAttack = false;
        }
    }

    private void Die()
    {
        isDying = true;
        aIPath.enabled = false;
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
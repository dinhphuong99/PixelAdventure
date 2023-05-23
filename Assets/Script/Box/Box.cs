using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float bounce = 5f;
    [SerializeField] private int typeBox = 1;
    private Rigidbody2D rb;
    //  1 <= maxHealth <=3
    [SerializeField] private int maxHealth = 4;
    private int currentHealth;
    private GameObject box;
    private Collider2D boxCollider;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        anim = this.transform.parent.GetComponent<Animator>();
        box = this.transform.parent.gameObject;
        currentHealth = maxHealth;
        anim.Play("Idle_" + typeBox);
        boxCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            //boxCollider.enabled = false;
            if (boxCollider.isActiveAndEnabled)
            {
                boxCollider.enabled = false;
            }
            anim.Play("Break_" + typeBox);
            Invoke("Break", 1.2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && currentHealth > 0)
        {
            currentHealth--;
            anim.Play("Hit_" + typeBox);
            rb.velocity = new Vector2(rb.velocity.x, bounce);
        }
    }

    private void Break()
    {
        box.SetActive(false);
    }
}

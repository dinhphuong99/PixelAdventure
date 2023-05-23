using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float bounce = 10f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("Idle");
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") 
    //        || anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.1f)
    //    {
    //        anim.Play("Idle");
    //    }
    //    else
    //    {
    //        anim.Play("Jump");
    //    };
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.Play("Jump");
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, bounce);
            //collision.gameObject.GetComponent<Rigidbody2D>().
            //AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }

    private void Off()
    {
        anim.Play("Idle");
    }
}

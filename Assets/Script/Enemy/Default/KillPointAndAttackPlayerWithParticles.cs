using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPointAndAttackPlayerWithParticles : MonoBehaviour
{
    private PlayerLife playerLife;
    [SerializeField] private GameObject[] particles;
    private GameObject head;
    private GameObject foot;
    private GameObject bodyParent;
    private Collider2D boxCollider;
    [SerializeField] private float timeDeathDelay = 0.7f;
    [SerializeField] private float timeHideParticlesDelay = 0.7f;
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
        head = this.transform.gameObject;
        foot = this.transform.parent.GetChild(1).gameObject;
        bodyParent = this.transform.parent.gameObject;
        boxCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDying) return;

        if (collision.gameObject.CompareTag("PointKill"))
        {
            isDeath = true;
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDying) return;

        if (collision.gameObject.CompareTag("Player"))
        {
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

    private void Die()
    {
        isDying = true;
        boxCollider.enabled = false;
        StartCoroutine(WaitAndDisable());
    }

    private IEnumerator WaitAndDisable()
    {
        yield return new WaitForSeconds(timeDeathDelay);
        isDying = false;
        head.SetActive(false);
        foot.SetActive(false);
        bodyParent.GetComponent<SpriteRenderer>().enabled = false;
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].SetActive(true);
        }

        Invoke("HideParticles", timeHideParticlesDelay);
    }

    private void HideParticles()
    {
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].SetActive(false);
        }
        bodyParent.SetActive(false);
    }
}
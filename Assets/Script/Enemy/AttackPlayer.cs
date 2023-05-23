using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    private PlayerLife playerLife;
    private KillPoint killPoint;
    private bool isAttack = false;
    private bool isDeath = true;

    public bool GetIsAttack()
    {
        return this.isAttack;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerLife = player.GetComponent<PlayerLife>();
        killPoint = this.transform.GetChild(0).GetComponent<KillPoint>();
    }

    private void Update()
    {
        isDeath = killPoint.GetIsDeath();
        if (isAttack && !isDeath)
        {
            playerLife.TakeOneDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isAttack = true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    private PlayerLife playerLife;
    private float currentTime;
    private bool isBurn = false;
    private float flameTime = 1f;
    private float flameTimer = 0f;
    private float lastTime;
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerLife = player.GetComponent<PlayerLife>();
    }

    void Update()
    {
        if (!isBurn)
        {
            float currentTime = Time.realtimeSinceStartup;
            float elapsedTime = currentTime - lastTime;
            lastTime = currentTime;

            flameTimer += elapsedTime;
            if (flameTimer >= flameTime)
            {
                isBurn = true;
            }
        }
    }

    private void BurningFire()
    {
        playerLife.TakeOneDamage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isBurn)
        {
            // Bắt đầu tính thời gian bị cháy khi va chạm vào Flame
            InvokeRepeating("BurningFire", 0f, 0.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Dừng tính thời gian bị cháy khi rời khỏi Flame
            CancelInvoke("BurningFire");
        }
    }
}

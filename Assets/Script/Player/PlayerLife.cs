using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private PlayerAnimation playerAnimation;
    private Rigidbody2D rb;
    [SerializeField] private PlayerSound playerSound;
    [SerializeField] private GameObject pauseMenuCanvas;

    private int maxHealth = 3;
    private int currentHealth;
    private bool isInvulnerable = false;
    private float invulnerabilityTime = 3.5f;
    private float invulnerabilityTimer = 0f;

    private int healthRecovery = 1;

    // Start is called before the first frame update
    private void Start()
    {
        pauseMenuCanvas.transform.GetChild(1).gameObject.SetActive(true);
        pauseMenuCanvas.SetActive(false);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
        currentHealth = maxHealth;
        isInvulnerable = false;
    }

    private void Update()
    {
        if (isInvulnerable)
        {
            invulnerabilityTimer += Time.deltaTime;
            if (invulnerabilityTimer >= invulnerabilityTime)
            {
                isInvulnerable = false;
                invulnerabilityTimer = 0f;
            }
        }
    }

    public void TakeOneDamage()
    {
        if (!isInvulnerable)
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                isInvulnerable = true;
                invulnerabilityTimer = 0f;
                playerAnimation.SetTakeDamage(true);
            }
        }
    }

    private void HealOneHealth()
    {
        currentHealth += healthRecovery;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && !isInvulnerable)
        {
            TakeOneDamage();
        }
        else if (collision.gameObject.CompareTag("Heath"))
        {
            HealOneHealth();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && !isInvulnerable)
        {
            TakeOneDamage();
        }
        else if (collision.gameObject.CompareTag("Heath"))
        {
            HealOneHealth();
            Destroy(collision.gameObject);
        }
    }

    private void Die()
    {
        if (!isInvulnerable)
        {
            playerSound.PlayDeathSound();
            rb.bodyType = RigidbodyType2D.Static;
            playerAnimation.SetDead(true);
            Invoke("Pause", 1f);
        }
    }

    public int GetCurrentHealth()
    {
        return this.currentHealth;
    }

    private void Pause()
    {
        pauseMenuCanvas.transform.GetChild(1).gameObject.SetActive(false);
        pauseMenuCanvas.SetActive(true);
    }
}

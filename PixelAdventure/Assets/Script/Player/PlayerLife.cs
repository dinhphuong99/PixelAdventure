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

    private int maxHealth = 3;
    private int currentHealth;
    private bool isInvulnerable = false;
    private float invulnerabilityTime = 1.5f;
    private float invulnerabilityTimer = 0f;

    private int healthRecovery = 1;

    // Start is called before the first frame update
    private void Start()
    {
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
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && !isInvulnerable)
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                //playerSound.PlayHurtSound();
                isInvulnerable = true;
                invulnerabilityTimer = 0f;
            }
        }
        else if (collision.gameObject.CompareTag("Heath"))
        {
            currentHealth += healthRecovery;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
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
            Invoke("RestartLevel", 2f);
        }
    }

    public int GetCurrentHealth()
    {
        return this.currentHealth;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

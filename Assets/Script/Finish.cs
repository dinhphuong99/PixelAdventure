using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioSource finishSound;
    private bool levelCompleted = false;
    private Animator anim;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        GameObject player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            rb.bodyType = RigidbodyType2D.Static;
            finishSound.Play();
            levelCompleted = true;
            anim.Play("Finish_Hit");
            Invoke("CompleteLevel", 1.5f);
        }
    }

    private void CompleteLevel()
    {
        levelCompleted = false;
        SceneManager.LoadScene("Select Level");
    }
}

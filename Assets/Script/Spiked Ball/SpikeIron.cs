using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeIron : MonoBehaviour
{

    private PlayerLife playerLife;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerLife = player.GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerLife.TakeOneDamage();
        }
    }
}

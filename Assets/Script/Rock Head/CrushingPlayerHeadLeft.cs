using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushingPlayerHeadLeft : MonoBehaviour
{
    private WallHitAndCheckWall wallHitAndCheckWall;
    private bool checkLeftWall = false;
    private PlayerLife playerLife;
    private bool isTouchPlayer = false;
    // Start is called before the first frame update

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerLife = player.GetComponent<PlayerLife>();
        wallHitAndCheckWall = transform.parent.GetComponent<WallHitAndCheckWall>();
    }

    private void Update()
    {
        checkLeftWall = wallHitAndCheckWall.GetCheckLeftWall();
        CrushingPlayer(isTouchPlayer, checkLeftWall);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isTouchPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isTouchPlayer = false;
        }
    }

    private void CrushingPlayer(bool isTouchPlayer, bool checkLeftWall)
    {
        if (isTouchPlayer && checkLeftWall)
        {
            playerLife.TakeOneDamage();
        }
    }
}
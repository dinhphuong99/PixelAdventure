using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushingPlayerHeadRight : MonoBehaviour
{
    private WallHitAndCheckWall wallHitAndCheckWall;
    private bool checkRightWall = false;
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
        checkRightWall = wallHitAndCheckWall.GetCheckRightWall();
        CrushingPlayer(isTouchPlayer, checkRightWall);
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

    private void CrushingPlayer(bool isTouchPlayer, bool checkRightWall)
    {
        if(isTouchPlayer && checkRightWall)
        {
            playerLife.TakeOneDamage();
        }
    }
}
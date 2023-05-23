using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBirdDie : MonoBehaviour
{
    private FatBirdMoving fatBirdMoving;
    private KillPointAndAttackPlayer killPointAndAttackPlayer;

    // Start is called before the first frame update
    void Start()
    {
        fatBirdMoving = GetComponent<FatBirdMoving>();
        killPointAndAttackPlayer = GetComponent<KillPointAndAttackPlayer>();
    }

    private void Update()
    {
        if (killPointAndAttackPlayer.GetIsDeath())
        {
            fatBirdMoving.enabled = false;
        }
    }
}

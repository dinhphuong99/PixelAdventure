using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBirdDie : MonoBehaviour
{
    private MovingWithWaitTime movingWithWaitTime;
    private KillPointAndAttackPlayer killPointAndAttackPlayer;

    // Start is called before the first frame update
    void Start()
    {
        movingWithWaitTime = GetComponent<MovingWithWaitTime>();
        killPointAndAttackPlayer = GetComponent<KillPointAndAttackPlayer>();
    }

    private void Update()
    {
        if (killPointAndAttackPlayer.GetIsDeath())
        {
            movingWithWaitTime.enabled = false;
        }
    }
}

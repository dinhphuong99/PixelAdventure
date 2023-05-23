using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoDie : MonoBehaviour
{
    private RinoMoving rinoMoving;
    private KillPointAndAttackPlayer killPointAndAttackPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rinoMoving = GetComponent<RinoMoving>();
        killPointAndAttackPlayer = GetComponent<KillPointAndAttackPlayer>();
    }

    private void Update()
    {
        if (killPointAndAttackPlayer.GetIsDeath())
        {
            rinoMoving.enabled = false;
        }
    }
}

using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatDie : MonoBehaviour
{
    private AIDestinationSetter aIDestinationSetter;
    private BatKillPoint batKillPoint;

    // Start is called before the first frame update
    void Start()
    {
        aIDestinationSetter = this.transform.parent.GetComponent<AIDestinationSetter>();
        batKillPoint = GetComponent<BatKillPoint>();
    }

    private void Update()
    {
        if (batKillPoint.GetIsDeath())
        {
            aIDestinationSetter.enabled = false;
        }
    }
}

using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBehaviour : MonoBehaviour
{
    private CollisionDetection collisionDetection;
    private AIDestinationSetter aIDestinationSetter;
    [SerializeField] private GameObject wayPoint;
    private bool isCellingOut = false;
    private bool isCellingIn = false;
    private bool isFlying = false;

    public bool GetIsCellingOut()
    {
        return this.isCellingOut;
    }

    public bool GetIsCellingIn()
    {
        return this.isCellingIn;
    }

    public bool GetIsFlying()
    {
        return this.isFlying;
    }

    // Start is called before the first frame update
    void Start()
    {
        collisionDetection = this.transform.parent.GetChild(2).GetComponent<CollisionDetection>();
        aIDestinationSetter = GetComponent<AIDestinationSetter>();
    }

    private void Update()
    {
        if (Vector2.Distance(wayPoint.transform.position, transform.position) >= 0.7f)
        {
            isCellingIn = false;
            isCellingOut = false;
        }
        
        if (isFlying && !collisionDetection.GetIsTouch() 
            && Vector2.Distance(wayPoint.transform.position, transform.position) <= 0.5f)
        {
            isCellingIn = true;
            isFlying = false;
            isCellingOut = false;
        }

        if (!collisionDetection.GetIsTouch()
            && Vector2.Distance(wayPoint.transform.position,
            transform.position) == 0f)
        {
            aIDestinationSetter.enabled = false;
        }

        if (collisionDetection.GetIsTouch() && !isFlying)
        {
            isCellingIn = false;
            isFlying = false;
            isCellingOut = true;
        }
    }

    public void CellingOutDone()
    {
        isCellingOut = false;
        isCellingIn = false;
        isFlying = true;
        aIDestinationSetter.enabled = true;
    }

    public void CellingInDone()
    {
        isCellingIn = false;
        isCellingOut = false;
        aIDestinationSetter.enabled = false;
    }
}

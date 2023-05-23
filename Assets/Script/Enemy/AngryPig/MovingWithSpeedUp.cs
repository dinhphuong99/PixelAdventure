using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWithSpeedUp: MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float speedUp = 3f;
    private float actualSpeed = 2f;
    [SerializeField] private float waitingTime = 3.5f;
    private CollisionDetection collisionDetection;
    private bool isSpeedUp = false;
    private bool isWaiting = false;
    private float waitingTimer = 0f;

    public int GetCurrentWaypointIndex()
    {
        return this.currentWaypointIndex;
    }

    public bool GetIsWaiting()
    {
        return this.isWaiting;
    }

    public bool GetIsSpeedUp()
    {
        return this.isSpeedUp;
    }

    private void Start()
    {
        collisionDetection = this.transform.GetChild(2).GetComponent<CollisionDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaiting && Vector2.Distance(waypoints[currentWaypointIndex].transform.position,
            transform.position) < 0.01f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }

            isSpeedUp = false;
            isWaiting = true;
            actualSpeed = speed;
        }

        if (collisionDetection.GetIsTouch())
        {
            isWaiting = false;
            waitingTimer = 0f;
            isSpeedUp = true;
            actualSpeed = speed + speedUp;
        }

        if (isWaiting)
        {
            waitingTimer += Time.deltaTime;
            if (waitingTimer >= waitingTime)
            {
                isWaiting = false;
                waitingTimer = 0f;
            }
        }

        if (!isWaiting)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[currentWaypointIndex].transform.position, Time.deltaTime * actualSpeed);
        }
    }
}
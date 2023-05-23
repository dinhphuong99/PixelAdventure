using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWithWaitTime : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float waitingTime = 3.5f;
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

            isWaiting = true;
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
            waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
    }
}
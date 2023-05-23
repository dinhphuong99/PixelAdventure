using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHead : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex;
    [SerializeField] private int firstWaypointIndex = 0;
    [SerializeField] private float speed = 15f;

    public int GetCurrentWaypointIndex()
    {
        return this.currentWaypointIndex;
    }

    private void Start()
    {
        currentWaypointIndex = firstWaypointIndex;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.01f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex == waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
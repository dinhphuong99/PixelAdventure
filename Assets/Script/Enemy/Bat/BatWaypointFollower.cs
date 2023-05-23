using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatWaypointFollower : MonoBehaviour
{
    private CollisionDetection collisionDetection;
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;

    void Start()
    {
        collisionDetection = this.transform.parent.GetChild(2).GetComponent<CollisionDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collisionDetection.GetIsTouch())
        {
            currentWaypointIndex = 0;
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
        else
        {
            currentWaypointIndex = 1;
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
    }
}
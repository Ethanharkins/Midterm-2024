using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public List<Transform> waypoints; // List of waypoints to be set in the Inspector
    public float moveSpeed = 10f;
    private int waypointIndex = 0;

    void Start()
    {
        if (waypoints.Count > 0)
        {
            transform.position = waypoints[0].position; // Start at the first waypoint
        }
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (waypointIndex >= waypoints.Count) return; // Check if we've reached the last waypoint

        Vector3 target = waypoints[waypointIndex].position;
        Vector3 dir = target - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        // If close enough to the current waypoint, move to the next one
        if (Vector3.Distance(transform.position, target) < 0.4f)
        {
            waypointIndex++;
        }
    }
}

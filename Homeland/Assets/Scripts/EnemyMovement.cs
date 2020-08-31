using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;
    private float distance_range = 0.4f;
    private Transform target;
    private int waypointIndex = 0;

    public void Start()
    {
        target = Waypoints.waypoints[0];
    }

    // Make the enemy move towards the next waypoint
    public void Update()
    {
        Vector3 direction = target.position - this.transform.position;
        this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(this.transform.position, target.position) <= distance_range)
        {
            findNextWaypoint();
        }           
    }

    /// <summary>
    /// Set the next waypoint as target such that the enemy can move towards it.
    /// If enemy reaches the last waypoint, destroy the enemy game object.
    /// </summary>
    private void findNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // Array of the positions of the waypoints
    public static Transform[] waypoints;

    // Instantiate waypoints 
    public void Awake()
    {
        waypoints = new Transform[this.transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = this.transform.GetChild(i);
        }
    }

}
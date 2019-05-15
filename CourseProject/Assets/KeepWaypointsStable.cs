using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class KeepWaypointsStable : MonoBehaviour
{
    private Transform startMarker, endMarker;
    private Transform[] waypoints;
    private LineRenderer lineRenderer;
    private Waypoints waypointsScript;

    private void Start()
    {
        waypointsScript = GetComponent<Waypoints>();
        waypoints = GetComponent<Waypoints>().GetWaypoints();
    }
    void Update()
    {
        if (!waypointsScript.enabled)
        {
            for (int i = 0; i < waypoints.Length - 1; i++)
            {
                lineRenderer = waypoints[i].GetComponent<LineRenderer>();
                lineRenderer.enabled = true;
                Vector3 startPosition = waypoints[i].position;
                Vector3 endPosition = waypoints[i + 1].position;
                lineRenderer.SetPosition(0, startPosition);
                lineRenderer.SetPosition(1, endPosition);
            }
        }
    }
}
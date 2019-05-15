using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseLineRender : MonoBehaviour
{
    public float AddedWidth;
    public float frequency;
    public float maxWidth;
    public float minWidth;


    private bool UpPulse;
    private bool DownPulse;

    private Transform[] waypoints;
    private LineRenderer lineRenderer;
    private WaitForSeconds wait;
    void Start()
    {
        UpPulse = true;
        DownPulse = false;
        waypoints = GetComponent<Waypoints>().GetWaypoints();

        StartCoroutine("Pulse");
    }
    IEnumerator Pulse()
    {
        while (true) 
        {
            while (UpPulse)
            {
                for (int i = 0; i < waypoints.Length - 1; i++) 
                {
                    Debug.Log("UpPulse");
                    lineRenderer = waypoints[i].GetComponent<LineRenderer>();
                    lineRenderer.startWidth += AddedWidth;

                    if (lineRenderer.startWidth > maxWidth)
                    {

                        lineRenderer.startWidth = maxWidth;
                        UpPulse = false;
                        DownPulse = true;
                    }
                    lineRenderer.endWidth = lineRenderer.startWidth;
                }
                WaitForSeconds wait = new WaitForSeconds(frequency);
                yield return wait;
            }
            while (DownPulse)
            {
                for (int i = 0; i < waypoints.Length - 1; i++)
                {
                    lineRenderer = waypoints[i].GetComponent<LineRenderer>();
                    lineRenderer.startWidth -= AddedWidth;
                    if (lineRenderer.startWidth < minWidth)
                    {
                        lineRenderer.startWidth = minWidth;
                        UpPulse = true;
                        DownPulse = false;
                    }
                    lineRenderer.endWidth = lineRenderer.startWidth;
                }
                yield return new WaitForSeconds(frequency);
            }
        }
    }

    public void StopPulsing()
    {
        StopCoroutine("Pulse");
    }
}
using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class Waypoints : MonoBehaviour
{
    public bool hasContinuation;
    public GameObject[] targetContinue;
    private Transform startMarker, endMarker;
    private Transform[] waypoints;
    public float speed = 30f;
    private float startTime = 0f;
    private float journeyLength = 1f;
    private int currentStartPoint = 0;
    private LineRenderer lineRenderer;
    void Start()
    {
        waypoints = transform.Cast<Transform>().ToArray();
        SetPoints();
        waypoints[0].GetChild(0).gameObject.SetActive(true); // activate first node VFX
    }
    void SetPoints()
    {
        lineRenderer = waypoints[currentStartPoint].GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        startMarker = waypoints[currentStartPoint];
        endMarker = waypoints[currentStartPoint + 1];
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        Vector3 startPosition = startMarker.position;
        Vector3 endPosition = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);
        if (fracJourney >= 1f)
        {
            if (currentStartPoint + 2 < waypoints.Length)
            {
                currentStartPoint++;
                SetPoints();
                waypoints[currentStartPoint].GetChild(0).gameObject.SetActive(true); // activate next node's VFX 
            }
            else
            {
                //if finished, start another waypoint if it exists
                if (hasContinuation)
                {
                    foreach (GameObject target in targetContinue)
                    {
                        target.SetActive(true);
                        target.GetComponent<Waypoints>().enabled = true;
                    }
                }
                StartCoroutine("waitAndDisable");
            }
        }

    }

    public Transform[] GetWaypoints()
    {
        return transform.Cast<Transform>().ToArray();
    }

    IEnumerator waitAndDisable()
    {
        yield return new WaitForSeconds(2);
        this.enabled = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveOrbs : MonoBehaviour
{
public Transform[] points;
private int destPoint=0;
public NavMeshAgent agent;
private AudioSource audio;

//

    public GameObject point1GameObject;
public GameObject point2GameObject;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = true;
        agent.isStopped = false;

        GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
//        if (audio.time >= 59)
//        {
//            agent.isStopped = false;
//        }
        
        if (!agent.pathPending && agent.remainingDistance <= 0.0f)
        {
            if (destPoint == 1)
            {
                point1GameObject.SetActive(true);
                point2GameObject.SetActive(false);
            }
            else if (destPoint == 2)
            {
                point1GameObject.SetActive(false);
                point2GameObject.SetActive(true);
            }
            GotoNextPoint();
        }
        
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        

        agent.destination = points[destPoint].position;
        
        

        destPoint = (destPoint + 1) % points.Length;
    }

   public void SetAgent(bool isStopped)
    {
        
        this.agent.isStopped = isStopped;
    }
    
}

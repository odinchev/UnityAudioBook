using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    // this script is for the gameobject to look at a target. it is used in the menu scene to 
    // look at the controller.
    public Transform target;
    // Start is called before the first frame update
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation= Quaternion.Slerp(transform.rotation,Quaternion.LookRotation( transform.position - target.transform.position),Time.deltaTime);
    }
}

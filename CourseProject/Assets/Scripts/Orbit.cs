using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Orbit : MonoBehaviour
{
public GameObject player; // the object that the gameobject will circle

public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        speed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        OrbitAround();
    }

    public void OrbitAround()
    {
        transform.RotateAround(player.transform.position,Vector3.up,speed*Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Animator anim;

    private int pickANumber;

    private int randomInt;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if (transform.CompareTag("Lamb")  )
        {
            anim.Play("idle");
        }
        else if (transform.CompareTag("Wolf") )
        {
            anim.Play("idle 1");
        }


    }

    // Update is called once per frame
    void Update()
    {
         
    }
}

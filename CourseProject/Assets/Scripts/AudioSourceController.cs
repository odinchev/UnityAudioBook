using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    private AudioSource audio;

    private MoveOrbs orbs;  
    // Start is called before the first frame update
    void Start()
    {
        orbs = GetComponent<MoveOrbs>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audio.time >= 59)
        {
            Debug.Log("Agent is active");
            orbs.SetAgent(false);
           
        }

        if (audio.time >= 62)
        {
            orbs.SetAgent(true);
            Debug.Log("Agent is not active");
        }
        
       
        
        
    }
    
}

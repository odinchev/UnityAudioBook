using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AudioSizeChanger : MonoBehaviour
{
    private int qSamples = 1024;

     float refValue = (float) 0.1;
     private float rmsValue;
      
     private float[] samples;
     private AudioSource audio;
    
     private float dbValue;
     private Color previouscolor;
     
     public GameObject innerSphere;
 
    
    // Start is called before the first frame update
    void Start()
    {
        samples = new float[qSamples];
        audio = GetComponent<AudioSource>();
        previouscolor  = this.GetComponent<MeshRenderer>().material.color;
        innerSphere.GetComponent<Renderer>().enabled = false;



    }

    // Update is called once per frame
    void Update()
    {
       
        UpdateSize();
        
    }
    
    void UpdateSize()
    {
        audio.GetOutputData(samples, 0);
        float sum=0f;
       
       
        for (int i = 0; i < qSamples; i++)
        {
            sum += samples[i] * samples[i];
        }

        rmsValue = Mathf.Sqrt(sum / qSamples);
        dbValue = 20 * Mathf.Log10(rmsValue / refValue);
        if (dbValue < -1 )
        {
            dbValue = -1f;
        }

        if (dbValue > 2)
        {
            dbValue = 2;
        }

        CheckDBValue();
     //   gameObject.transform.localScale = new Vector3(dbValue,dbValue,dbValue);
        
//        dbValue = 1f;

       Debug.Log(dbValue);
        
    }
IEnumerator CheckDBValue()
    {
        
//        if (dbValue >= -0.4 && dbValue < -0.9)
//        {
//            Debug.LogError("Wolf");
//        }
        if (dbValue >= -0.9 && dbValue <= 0.6)
        {
             
            Debug.Log("light active");
            innerSphere.GetComponent<Renderer>().enabled = true;
           
             


        }
        else
        {
//            Color materialColor = gameObject.GetComponent<Renderer>().material.color;
//            materialColor.a = 255f;
          
            Debug.Log("Light inactive");
            

           
            
        }

        yield return null;


    }
}

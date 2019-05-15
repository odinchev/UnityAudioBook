using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSizeChangerV2 : MonoBehaviour
{
    public int detail = 500;

    public float minValue = 1.0f;

    public float amplitude = 0.1f;

    private float randomAmpliturde = 1.0f;

    private Vector3 startScale;
    public AudioSource audio;

    
    
    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
        randomAmpliturde = Random.Range(1.0f, 3.0f);
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float[] info = new float[detail];
        audio.GetOutputData(info, 0);
        float packageData = 0.0f;

        for (int x = 0; x < info.Length; x++)
        {
            packageData += System.Math.Abs(info[x]);
        }

        transform.localScale =  new Vector3((packageData * amplitude)+startScale.y,(packageData * amplitude)+ startScale.y,(packageData*amplitude)+startScale.z);
    }
}

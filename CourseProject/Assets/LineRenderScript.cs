using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderScript : MonoBehaviour
{
    private LineRenderer line;
    public Transform origin;
    public Transform destin;
    public float lineDrawSpeed;
    private float maxLineWidth;
    private float counter;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        maxLineWidth = line.startWidth;
        counter = 0;
        //StartCoroutine("IncreaseWidthGradually");

    }

    void Update()
    {
        counter += 0.1f / lineDrawSpeed;
        line.SetPosition(0, origin.position);
        line.SetPosition(1, Vector3.Lerp(origin.position, destin.position, counter));
        //line.SetPosition(0, origin.position);
        //line.SetPosition(1, destin.position);
    }
    IEnumerator IncreaseWidthGradually()
    {
        while (line.startWidth < maxLineWidth)
        {
            line.startWidth += 0.01f * Time.deltaTime;
            Debug.Log("Increasing Width");
            yield return new WaitForSeconds(1f);
        }
    }
}

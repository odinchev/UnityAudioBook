using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuClicker : MonoBehaviour
{

    public GameObject rightHand;// right hand anchor
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            Pointer();
        }
    }

    void Pointer()
    {
        Vector3 look = rightHand.transform.forward;
        RaycastHit hit;
         
        if (Physics.Raycast(rightHand.transform.position,look , out hit))
        {
            SceneManager.LoadScene("SceneIHopeDoesntRefresh");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pohyb_Kamery : MonoBehaviour
{

    public float RychlostH = 2.0f;
    public float RychlostV = 2.0f;

    public GameObject target;

    private float yaw = 0.0f;
    private float pitch = 0.0f;


   
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {



       
            yaw += RychlostH * Input.GetAxis("Mouse X");
            pitch -= RychlostV * Input.GetAxis("Mouse Y");
        

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    }

    private void LateUpdate()
    {
     //   transform.LookAt(target.transform);
    }
}

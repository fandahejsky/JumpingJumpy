using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZmenaTelesa : MonoBehaviour
{
    [SerializeField]
   public GameObject sphere; 
    public GameObject cube;
    public GameObject rectangle;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        //zmìna na kostku
        if (Input.GetKeyDown(KeyCode.F))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);
            if (sphere.active == true)
            {
                
                cube.transform.position = sphere.transform.position;
                sphere.SetActive(false);
                cube.SetActive(true);
            }

            if (rectangle.active == true)
            {
                cube.transform.position = rectangle.transform.position;
                rectangle.SetActive(false);
                cube.SetActive(true);

            }


        }
        //Zmìna na kouli
        if (Input.GetKeyDown(KeyCode.G))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
            if (cube.active == true)
            {
                
                sphere.transform.position = cube.transform.position;
                cube.SetActive(false);
                sphere.SetActive(true);
            }
            if(rectangle.active == true)
            {
                sphere.transform.position = rectangle.transform.position;
                rectangle.SetActive(false);
                sphere.SetActive(true);
            }
        }
        ///zmìna na obdélník
        if (Input.GetKeyDown(KeyCode.H))
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
            if (cube.active == true)
            {
                rectangle.transform.position = cube.transform.position;
                cube.SetActive(false);
                rectangle.SetActive(true);

            }
            if(sphere.active == true)
            {
                rectangle.transform.position = sphere.transform.position;
                sphere.SetActive(false);
                rectangle.SetActive(true);
            }
        }
    }
}

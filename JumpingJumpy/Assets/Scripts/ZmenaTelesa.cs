using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZmenaTelesa : MonoBehaviour
{
    [SerializeField]
   public GameObject sphere; 
    public GameObject cube;
    public GameObject rectangle;

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
            if(cube.active == true)
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
            if(cube.active == true)
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

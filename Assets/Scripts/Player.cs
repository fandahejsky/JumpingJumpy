using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f; //Rychlost pohybu
    [SerializeField]
    private float gravity = 9.81f; //Gravitace
    [SerializeField]
    private float jumpSpeed = 3.5f; //Výška skoku
    /* [SerializeField]
     private float doubleJumpMultiplier = 0.5f;*/ //Double Jump

    private CharacterController controller;

    private float directionY;

    // private bool canDoubleJump = false; //Double Jump

// Start is called before the first frame update
void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");//Ovládání pohybu
        float verticalInput = Input.GetAxis("Vertical");//Ovládání pohybu

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);//Smìr pohybu

        if (controller.isGrounded) //Zajištìní aby hráè mohl skákat pouze když je na zemi
        {

            if (Input.GetButtonDown("Jump")) //Skákání
            {
               // canDoubleJump = true; //Double Jump
                directionY = jumpSpeed;
            }
        }
        /* else //Double Jump
         {
             if (Input.GetButtonDown("Jump") && canDoubleJump==true)
             {
                 directionY = jumpSpeed * doubleJumpMultiplier;
                 canDoubleJump = false;
             }
         }*/

        if (Input.GetKey(KeyCode.W))
        {
          
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = 9;
            }
            else
            {
                moveSpeed = 5;
            }
        }


        directionY -= gravity * Time.deltaTime;//Gravitace

        direction.y = directionY;

        controller.Move(direction * moveSpeed * Time.deltaTime); //Pohyb 
    }
}

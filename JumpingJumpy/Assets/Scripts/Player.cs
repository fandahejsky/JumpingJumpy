using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f; //Rychlost pohybu
    public float gravity = -9.81f;
    public float jumpHeight = 3f;


    public CharacterController controller;
    public Transform cam;
    float turnSmooth;
    float turnSmoothTime = 0.1f;
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    


    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)//resetování aplikovani gravitace
        {
            velocity.y = -2f;
        }
        float horizontalInput = Input.GetAxisRaw("Horizontal");//Ovladani pohybu
        float verticalInput = Input.GetAxisRaw("Vertical");//Ovladani pohybu

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;//Smer pohybu
        velocity.y += gravity * Time.deltaTime;//Usazeni zakladni gravitace nezavisle na fps
        controller.Move(velocity * Time.deltaTime);//Aplikovani gravitace (Funguje tak ze aplikuje negativni silu na y axis tak proto tam je nahore ten reset jinak by se to aplikovalo porad a kdybys vyskocil tak by te to hned hodilo dolu)
        if (Input.GetButtonDown("Jump") && isGrounded)//Skakani
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);//Vypocet skoku a nasledne provedeni
        }
        if (direction.magnitude >= 0.1f) //Pohyb hrace zavisle na kamere
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmooth, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);

            

            
        }

    }
}

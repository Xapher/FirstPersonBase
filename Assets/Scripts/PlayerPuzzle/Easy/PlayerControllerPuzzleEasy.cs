using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerControllerPuzzleEasy : MonoBehaviour
{
    CharacterController characterController;                      
    

    float jumpCast = 0f;                                            
    Vector3 moveDir = new Vector3();                              
    Vector3 rotDir = new Vector3();                                
    float moveSpeed = 0f;                                          
    float timeInAir = 0f;                                           
    bool onGround = false;                                         





    void Start()
    {
        characterController = GetComponent<CharacterController>();  
        Cursor.lockState = CursorLockMode.Locked;                   
        jumpCast = characterController.skinWidth + 1.03f;          
    }

    void Update()
    {
        if(onGround = isGrounded()) 
        {
            if(timeInAir > 0) 
            {
                timeInAir = 0f;
            }
        }
        else
        {
            timeInAir += Time.deltaTime;
        }

        moveDir.x = 0; 
        moveDir.y = 0;
        moveDir.z = 0;

        moveDir += ((transform.right * Input.GetAxis("Horizontal")) * moveSpeed) + ((transform.forward * Input.GetAxis("Vertical")) * moveSpeed);

        moveDir *= Time.deltaTime;


        if (Input.GetButtonDown("Jump") && onGround)
        {
            timeInAir = 0.5f;   
        }

        moveDir.x = 0;
        moveDir.y = 0;
        moveDir.z = 0;

        moveDir.y = (Physics.gravity.y * Time.deltaTime) * timeInAir;           
        characterController.Move(moveDir);          


        rotDir.y = Input.GetAxis("Mouse Y");  
        transform.Rotate(rotDir, Space.Self); 
    }




    RaycastHit ground;     
    bool isGrounded()  
    {
        if(Physics.Raycast(transform.position, -transform.up, out ground, jumpCast))
        {
            return true;
        }
        return false;
    }
}
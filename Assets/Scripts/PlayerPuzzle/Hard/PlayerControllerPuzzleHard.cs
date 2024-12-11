using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerControllerPuzzleHard : MonoBehaviour
{
    CharacterController characterController;                      
    

    float jumpCast = 0f;                                            
    Vector3 moveDir = new Vector3();                              
    Vector3 rotDir = new Vector3();                                
    float moveSpeed = -3f;                                          
    float timeInAir = 0f;                                           
    bool onGround = false;                                         





    void Start()
    {
        characterController = GetComponent<CharacterController>();  
        Cursor.lockState = CursorLockMode.Locked;                   
        jumpCast = characterController.skinWidth - 1.03f;          
    }

    void Update()
    {
        if(onGround = isGrounded()) 
        {
            if(timeInAir < 0) 
            {
                timeInAir = -1f;
            }
        }
        else
        {
            timeInAir -= Time.deltaTime;
        }

        moveDir -= ((transform.right * Input.GetAxis("Vertical")) * moveSpeed) + ((transform.forward * Input.GetAxis("Horizontal")) * moveSpeed);

        moveDir *= Time.deltaTime;


        if (Input.GetButtonDown("Horizontal") && !onGround)
        {
            timeInAir = 0.5f;   
        }

        moveDir.y -= (Physics.gravity.y * Time.deltaTime) * timeInAir;           
        characterController.Move(moveDir);          


        rotDir.z = Input.GetAxis("Mouse Y");  
        transform.Rotate(rotDir); 
    }




    RaycastHit ground;     
    bool isGrounded()  
    {
        if(Physics.Raycast(transform.position, transform.up, out ground, jumpCast))
        {
            return false;
        }
        return true;
    }
}

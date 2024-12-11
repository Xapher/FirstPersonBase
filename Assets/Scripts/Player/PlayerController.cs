using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    CharacterController characterController;                        //Character controller component to enable movement and such
    

    float jumpCast = 0f;                                            //The distance to raycast to detect if the player is on the ground
    Vector3 moveDir = new Vector3();                                //The Temp Direction the player is about to move
    Vector3 rotDir = new Vector3();                                 //The Temp Angles the player will rotate
    float moveSpeed = 3f;                                           //Move Speed Per Second (With * Time.DeltaTime)
    float timeInAir = 0f;                                           //Used to calculate time in air for a more "realistic" jump curve
    bool onGround = false;                                          //Replaces the characterController.onGround for better control





    void Start()// Start is called before the first frame update (When the game object is initialized)
    {
        characterController = GetComponent<CharacterController>();  //Gets the Character controller from the GameObject, this enables movement and other things
        Cursor.lockState = CursorLockMode.Locked;                   //locks cursor to screen
        jumpCast = characterController.skinWidth + 1.03f;           //calculates the distance needed to raycast for onGround check.Distance should be enough to reach the bottom of the character controller and some
    }

    

    // Update is called once per frame
    void Update()
    {
        if(onGround = isGrounded()) //Check if player is grounded
        {
            if(timeInAir > 0) //Checks if timeInAir is larger than 0, this prevents getting stuck when pressing "jump"
            {
                timeInAir = 0f;
            }
        }
        else
        {
            timeInAir += Time.deltaTime;
        }

        moveDir.x = 0;  //Reset the direction the player is moving
        moveDir.y = 0;
        moveDir.z = 0;

        moveDir += ((transform.right * Input.GetAxis("Horizontal")) * moveSpeed) + ((transform.forward * Input.GetAxis("Vertical")) * moveSpeed);
        //Calculate the move direction based on inputs.
        //transform.right for A-D, D is positive and A is negative
        //transform.forward for W-S, W is positive and S is negative

        moveDir *= Time.deltaTime;  //Multiply by time to normalize movement speed in a per second format


        if (Input.GetButtonDown("Jump") && onGround)
        {
            timeInAir = -0.5f;      //vague representation of negative force applied to character to make jump
        }

        moveDir.y = (Physics.gravity.y * Time.deltaTime) * timeInAir;           //apply the gravity/jump to the player, timeInAir effects the speed of gravity as gravity is an acceleration
        characterController.Move(moveDir);          //Move the character


        rotDir.y = Input.GetAxis("Mouse X");  //Get mouse movement to preset rotation angle
        transform.Rotate(rotDir, Space.Self); //rotates character in local space (Will rotate on the players XYZ Axis instead of global XYZ which will be different
    }




    RaycastHit ground;      //stored result from raycasting
    bool isGrounded()   //Checks if the player is close enough to the ground to be considered grounded
    {
        if(Physics.Raycast(transform.position, -transform.up, out ground, jumpCast))
        {
            return true;
        }
        return false;
    }
}

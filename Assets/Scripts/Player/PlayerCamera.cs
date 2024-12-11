using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    Vector2 rotDir = new Vector2();   //Stored variable for rotation
    PlayerController parent; //Stored reference to parent controller
    private void Start()
    {
        parent = GetComponentInParent<PlayerController>();
    }

    float parentRot = 0f, upRot = 0f, downRot = 0f;     //stored variabled to use for comparing later
    //parentRot = Angle between the camera and the direction the player is facing
    //upRot = Angle to global UP
    //downRot = Angle to global DOWN

    // Update is called once per frame
    void Update()
    {
        rotDir.x = -Input.GetAxis("Mouse Y"); //Get mouse input as rotation
        transform.Rotate(rotDir, Space.Self); //Rotate the camera in local space
        parentRot = Vector3.Angle(parent.transform.forward, transform.forward); //Get the rotation comparison between the camera and direction the player is facing

        if (parentRot > 90) //if the angle is past 90* (up or down)
        {
            upRot = Vector3.Angle(Vector3.up, transform.forward); //get the angle compared to global UP
            downRot = Vector3.Angle(-Vector3.up, transform.forward); //get the angle compared to global DOWN

            if (upRot < downRot) //if character is looking up past 90 degrees
            {
                rotDir.x = upRot; //set the rotation direction to the excess degrees
                transform.Rotate(rotDir, Space.Self);
            }
            else
            {
                rotDir.x = -downRot;//set the rotation direction to the inverse excess degrees
                transform.Rotate(rotDir, Space.Self);
            }
        }

    }
}

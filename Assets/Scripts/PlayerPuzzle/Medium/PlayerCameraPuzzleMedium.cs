using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraPuzzleMedium : MonoBehaviour
{
    Vector2 rotDir = new Vector2(); 
    PlayerController parent; 
    private void Start()
    {
        parent = GetComponentInParent<PlayerController>();
    }

    float parentRot = 0f, upRot = 0f, downRot = 0f;  
    void Update()
    {
        rotDir.x = -Input.GetAxis("Mouse Y"); 
        transform.Rotate(rotDir, Space.Self);
        parentRot = Vector3.Angle(parent.transform.forward, transform.up);

        if (parentRot < 0) 
        {
            upRot = Vector3.Angle(Vector3.up, transform.right); 
            downRot = Vector3.Angle(-Vector3.up, transform.up); 

            if (upRot < downRot) 
            {
                rotDir.x = upRot; 
                transform.Rotate(rotDir, Space.World);
            }
            else
            {
                rotDir.x = -downRot;
                transform.Rotate(rotDir, Space.World);
            }
        }

    }
}

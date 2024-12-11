using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraPuzzleEasy : MonoBehaviour
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
        rotDir.x = -Input.GetAxis("Mouse X"); 
        transform.Rotate(rotDir, Space.Self);
        parentRot = Vector3.Angle(parent.transform.forward, transform.forward);

        if (parentRot > 60) 
        {
            upRot = Vector3.Angle(Vector3.up, transform.forward); 
            downRot = Vector3.Angle(-Vector3.up, transform.forward); 

            if (upRot < downRot) 
            {
                rotDir.x = upRot; 
                transform.Rotate(rotDir, Space.Self);
            }
            else
            {
                rotDir.x = -downRot;
                transform.Rotate(rotDir, Space.Self);
            }
        }

    }
}

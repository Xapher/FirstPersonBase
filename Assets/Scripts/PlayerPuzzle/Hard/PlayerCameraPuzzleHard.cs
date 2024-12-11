using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraPuzzleHard : MonoBehaviour
{
    Vector2 rotDir = new Vector2(); 
    PlayerController parent; 
    private void Start()
    {
    }

    float parentRot = 0f, upRot = 0f, downRot = 0f;  
    void Update()
    {
        
        rotDir.x = -Input.GetAxis("Mouse X"); 
        parentRot = Vector3.Angle(Vector3.forward, transform.forward);

        if (parentRot < 180) 
        {
            upRot -= Vector3.Angle(transform.up, transform.forward); 
            downRot += Vector3.Angle(-transform.forward, transform.forward); 
            
            if (upRot > downRot) 
            {
                rotDir.x = upRot; 
                transform.Rotate(-rotDir);
            }
            else
            {
                rotDir.x = -downRot;
                transform.Rotate(rotDir);
            }
        }
        
    }
}

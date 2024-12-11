using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Vector3 spawn = new Vector3(0f, 1.5f, 0f);
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -20f)
        {
            GetComponent<CharacterController>().enabled = false;
            transform.position = spawn;
            GetComponent<CharacterController>().enabled = true;
        }
    }
}

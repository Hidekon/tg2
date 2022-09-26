using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotator : MonoBehaviour
{
    

    void Start()
    {
        Quaternion startQuaternion = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.U))
        {
            
            transform.Rotate(new Vector3(0, 1, 0));
        }
        
        if (Input.GetKey(KeyCode.M))
        {

            transform.rotation = new Quaternion(1, 0, 0, 0);
                            
        }

      
    }
    
}

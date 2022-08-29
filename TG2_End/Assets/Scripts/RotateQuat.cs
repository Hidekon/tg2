using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateQuat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90) * Quaternion.Euler(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

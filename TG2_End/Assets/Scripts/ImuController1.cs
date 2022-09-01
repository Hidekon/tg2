using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImuController1 : MonoBehaviour
{
    LegsRotation legRotation;
    [SerializeField] GameObject legsQuat;

    void Start()
    {
        legRotation = legsQuat.GetComponent<LegsRotation>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = legRotation.r_legTransf.rotation ;
    }
}

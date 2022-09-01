using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImuController2 : MonoBehaviour
{
    LegsRotation legRotation;
    [SerializeField] GameObject legsQuat;
    public Quaternion rotQuat = Quaternion.Euler(0, 0, 0);

    void Start()
    {
        legRotation = legsQuat.GetComponent<LegsRotation>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = legRotation.r_legTransf.rotation * rotQuat;
    }
}

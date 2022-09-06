using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateQuat : MonoBehaviour
{
    // Acess the string from another script

    LegsRotation legsRotation;
    //PrintQuat printQuat;

    [SerializeField] GameObject legR;
    public string[] s_text;


    public Quaternion quat;
    // Start is called before the first frame update
    void Start()
    {
        legsRotation = legR.GetComponent<LegsRotation>();

        //quat = Quaternion.Euler(-90, 0, -90);
        //transform.rotation = transform.localRotation * quat;

        //Debug.Log(quat);
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = legsRotation.q_RL;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Quaternion startQuaternion;
    public Transform legTransf;
    string stringQuat = "0.0, 0, 0.0, 1.0";
    public Quaternion newQuat;

    void Start()
    {
        startQuaternion = legTransf.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(legTransf.rotation);

            legTransf.Rotate(Vector3.up);
        }
        
        if (Input.GetKey(KeyCode.M))
        {

            legTransf.rotation = new Quaternion(1, 0, 0, 0);
                            
        }

        if (Input.GetKey(KeyCode.N))
        {
            newQuat = StringToQuaternion(stringQuat);
            legTransf.rotation = newQuat;

        }

    }

    public static Quaternion StringToQuaternion(string sQuaternion)
    {
        // Remove the parentheses
        if (sQuaternion.StartsWith("(") && sQuaternion.EndsWith(")"))
        {
            sQuaternion = sQuaternion.Substring(1, sQuaternion.Length - 2);
        }

        // split the items
        string[] sArray = sQuaternion.Split(',');
        Debug.Log(sArray);

        // store as a Vector3
        Quaternion result = new Quaternion(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]),
            float.Parse(sArray[3]));

        return result;
    }

}

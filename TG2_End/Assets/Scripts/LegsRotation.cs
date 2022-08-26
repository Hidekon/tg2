using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsRotation : MonoBehaviour
{
    // Get the transform of each parts of the legs.
    public Transform r_legTransf;
    public Transform r_kneeTransf;
    public Transform l_legTransf;
    public Transform l_kneeTransf;

    // Acess the string from another script

    UdpSocket udpSocket;
    //PrintQuat printQuat;
    
    [SerializeField] GameObject udp;
    public string[] s_text;

    void Awake()
    {
        udpSocket = udp.GetComponent<UdpSocket>();
        Debug.Log(s_text);
    }

    // Update is called once per frame
    void Update()
    {
        s_text = udpSocket.str_text;

                
        // Compare the IMU number to each part of the leg.
        // 1 = RLeg, 2 = RKnee, 3 = LLeg, 4 = LKnee;



        if (int.Parse(s_text[0]) == 1)
        {
            r_legTransf.rotation = StringToQuaternion(s_text[1]);   //Right Leg
        }

        if (int.Parse(s_text[0]) == 2)
        {
            r_kneeTransf.rotation = StringToQuaternion(s_text[1]);  //Right Knee
        }

        if (int.Parse(s_text[0]) == 4)
        {
            l_legTransf.rotation = StringToQuaternion(s_text[1]);   //Left Leg
        }

        if (int.Parse(s_text[0]) == 5)
        {
            l_kneeTransf.rotation = StringToQuaternion(s_text[1]);  //Left Knee
        }


    }

    //Functions ________________________________________________________________________________________________________
    public static Quaternion StringToQuaternion(string sQuaternion)
    {
        // Remove the brackets
        if (sQuaternion.StartsWith("[") && sQuaternion.EndsWith("]"))
        {
            sQuaternion = sQuaternion.Substring(1, sQuaternion.Length - 2);
        }

        
        // Split the items
        string[] sArray = sQuaternion.Split(',');
        Debug.Log(sQuaternion);

        // Store as a Quaternion
        Quaternion result = new Quaternion(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]),
            float.Parse(sArray[3]));

        return result;
    }


}

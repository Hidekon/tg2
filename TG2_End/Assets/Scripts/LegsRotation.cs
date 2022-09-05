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

    Quaternion rLeg_StartQuat;
    Quaternion rKnee_StartQuat;
    Quaternion lLeg_StartQuat;
    Quaternion lKnee_StartQuat;

    Quaternion quat_RLeg_Offset;
    Quaternion quat_RKnee_Offset;
    Quaternion quat_LLeg_Offset;
    Quaternion quat_LKnee_Offset;


    public Quaternion quaternionRLegOffset;

    
    Quaternion rotQuatZ = Quaternion.Euler(0, 0, 90);


    void Awake()
    {
        // Create a udp component to grab the data from de UdpSocket script
        udpSocket = udp.GetComponent<UdpSocket>();

        // Grab the initial orientation from the legs
        rLeg_StartQuat = r_legTransf.rotation;
        rKnee_StartQuat = r_kneeTransf.rotation;
        lLeg_StartQuat = l_legTransf.rotation;
        lKnee_StartQuat = l_kneeTransf.rotation;

        
        Debug.Log(s_text);
    }

    // Update is called once per frame
    void Update()
    {
        s_text = udpSocket.str_text;


        // Compare the IMU number to each part of the leg.
        // 1 = RLeg, 2 = RKnee, 3 = LLeg, 4 = LKnee;

        if (Input.GetKey(KeyCode.Space))
        {
            if (int.Parse(s_text[0]) == 1)
            {
                quat_RLeg_Offset = Quaternion.Inverse(StringToQuaternion(s_text[1])) * rLeg_StartQuat;                                
            }

            if (int.Parse(s_text[0]) == 2)
            {
                quat_RKnee_Offset = Quaternion.Inverse(StringToQuaternion(s_text[1])) * rKnee_StartQuat;
            }

            if (int.Parse(s_text[0]) == 4)
            {
                quat_LLeg_Offset = Quaternion.Inverse(StringToQuaternion(s_text[1])) * lLeg_StartQuat;
            }

            if (int.Parse(s_text[0]) == 5)
            {
                quat_LKnee_Offset = Quaternion.Inverse(StringToQuaternion(s_text[1])) * lKnee_StartQuat;
            }

        }

        if (Input.GetKey(KeyCode.C))
        {
            //Send data to python to tare sensor
            udpSocket.SendData("c");
        }


        if (int.Parse(s_text[0]) == 1)
        {
                                    
            r_legTransf.rotation = StringToQuaternion(s_text[1]) * quat_RLeg_Offset ;  //Right Leg
        }

        if (int.Parse(s_text[0]) == 2)
        {
            r_kneeTransf.rotation = StringToQuaternion(s_text[1]) * quat_RKnee_Offset;  //Right Knee
        }

        if (int.Parse(s_text[0]) == 4)
        {
            l_legTransf.rotation = StringToQuaternion(s_text[1]) * quat_LLeg_Offset;   //Left Leg
        }

        if (int.Parse(s_text[0]) == 5)
        {
            l_kneeTransf.rotation = StringToQuaternion(s_text[1]) * quat_LKnee_Offset;  //Left Knee
        }

         
    }

    //Functions ________________________________________________________________________________________________________
    public static Quaternion StringToQuaternion(string sQuaternion)
    {                              
        // Split the items
        string[] sArray = sQuaternion.Split(',');       
        // Store as a Quaternion
        Quaternion result = new Quaternion( float.Parse(sArray[0]), float.Parse(sArray[1]), 
                                            float.Parse(sArray[2]), float.Parse(sArray[3]));

        return result;
    }
        
}

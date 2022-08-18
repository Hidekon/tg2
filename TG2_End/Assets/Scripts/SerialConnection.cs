using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialConnection : MonoBehaviour
{
    SerialPort data_stream = new SerialPort("COM4", 115200);
    public string receivedstring;
    public Transform leg;
    string[] s_nums;
    float[] nums;

    Quaternion quat;
    


    void Start()
    {
        data_stream.Open();    
    }

    // Update is called once per frame
    void Update()
    {
        receivedstring = data_stream.ReadLine();

        s_nums = receivedstring.Split(',');

        Debug.Log(receivedstring);


        for ( int i = 0; i < 4; i++)
        {
            nums[i] = float.Parse(s_nums[i]);
        }

        quat = new Quaternion(nums[0], nums[1], nums[2], nums[3]);

        

        leg.rotation = quat;
        

    }
}

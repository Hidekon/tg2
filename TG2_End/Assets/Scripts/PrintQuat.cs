using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintQuat : MonoBehaviour
{
    string text2 = "2:[0,0,0,1]";
    
    public string[] str_text;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        str_text = text2.Split(':');
              
       
    }

 /*   IEnumerator Test()
    {
        yield return new WaitForSeconds(0.1f);
    }
 */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public GameObject tip;
    public Vector3 tipPosition;
    public float distance;

    Vector3 prevTipPosition;

    // Start is called before the first frame update
    void Start()
    {
        tipPosition = tip.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(tipPosition);
        prevTipPosition = tipPosition;

        transform.Translate(0, 0, distance * Time.deltaTime);
        
    }

    Vector3 CalculateDistance()
    {
        Vector3 distance = tipPosition - prevTipPosition;

        return distance;
    }
}

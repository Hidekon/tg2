using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTarget : MonoBehaviour
{ 
    
    public bool isCounting = false;
    public Collider handCol;

    //public GameObject target;
    //private Transform trans;
    //Vector3 randomPos;

    public void OnTriggerEnter(Collider Col)
    {
        PointsCollector pointsCollected = Col.GetComponent<PointsCollector>();



        if (pointsCollected != null)
        {
            isCounting = true;
            pointsCollected.TargetHit();
            transform.position = new Vector3(Random.Range(-20, 20) *0.1f , 1, 1);
            
            
        }
    }
}
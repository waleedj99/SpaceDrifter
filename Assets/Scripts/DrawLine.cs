using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    LineRenderer Lr;
    public bool consumeTime;
    // Start is called before the first frame update
    void Start()
    {
        Lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Lr.SetPosition(0,GameObject.Find("ShipTop").GetComponent<Transform>().position);
        Lr.SetPosition(1, GetComponent<Transform>().position);
        
        var distance = (Lr.GetPosition(0) - Lr.GetPosition(1)).sqrMagnitude;
        Debug.Log(distance);
        if(distance<450){
            consumeTime = true;
        }else{
            consumeTime = false;
        }
            
    }
}

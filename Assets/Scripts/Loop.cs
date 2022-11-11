using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;

public class Loop : MonoBehaviour
{
    public LogicComponent x;
    public LogicComponent y;

    

    // Start is called before the first frame update
    void Start()
    {
        //output 1 to input 1 
        x.bridge.links[0].CreateRelation(y, 0);
        //output 1 to input 2
        x.bridge.links[0].CreateRelation(y, 1);
        //output 1 to input 1
        y.bridge.links[0].CreateRelation(x, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

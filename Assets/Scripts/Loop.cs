using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;

public class Loop : MonoBehaviour
{
    public LogicGate gate;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gate.GetInputs());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

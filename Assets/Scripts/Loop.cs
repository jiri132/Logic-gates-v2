using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;

public class Loop : MonoBehaviour
{
    [Range(0,1)]
    public int input_value;

    public LogicGate gate1;
    

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(gate.GetInputs());
        
    }

    // Update is called once per frame
    void Update()
    {
        //gate.SetInputData(input_value,0);
    }
}

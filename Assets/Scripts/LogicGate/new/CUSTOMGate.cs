using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;

public class CUSTOMGate : LogicComponent
{
    #region Constructor

    public CUSTOMGate(int inputs, int outputs, string name)
    {
        base.name = name;
        base.inputs = new int[inputs];
        base.outputs = new int[outputs];
    }

    #endregion

    #region Variables

    [Header("Linking Bridge")]
    [SerializeField]
    private LogicLink[] link = new LogicLink[0];

   
    #endregion

    public override void Start()
    {
        
    }

    #region Overrides Of Component
    /*public override int[] GetInputData()
    {
        return inputs;
    }

    public override int[] GetOutputData()
    {
        return outputs;
    }

    public override void SetInputData(int[] data)
    {
        inputs = data;
    }

    public override void SetInputData(int data, int index)
    {
        inputs[index] = data;
    }*/
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;
using Logic.Nodes;
using System;
using System.Linq;

[System.Serializable]
public class GateData 
{
    //Name of the gate and the color
    public string Name;
    public float[] rgb = new float[3];

    //The number of inputs used for the gates, inputs, outputs
    public int NumberOfGates;
    public int NumberOfIputs;
    public int NumberOfOutputs;

    //format <ID,gate name> 
    public Dictionary<int, string> GateSpawnFormat = new Dictionary<int, string>();
    //format <ID,Output of ID, Conneciton ID, input of connection>
    public List<Tuple<int, int, int, int>> Connections = new List<Tuple<int, int, int, int>>();

   
    public GateData(bool DEBUG)
    {
        Name = Enviorment.Instance.gateNameInput.text;
        rgb = new float[3] { Enviorment.Instance.randomColor.r, Enviorment.Instance.randomColor.g, Enviorment.Instance.randomColor.b };

        NumberOfGates = GameManager.Instance.AllGates.Count;
        NumberOfIputs = Enviorment.Instance.GetComponent<EnviormentGate>().inputs.Length;
        NumberOfOutputs = Enviorment.Instance.GetComponent<EnviormentGate>().outputs.Length;


        //Add the Dictionary
        for (int i = 0; i < NumberOfGates; i++)
        {
            LogicComponent gate = GameManager.Instance.AllGates[i];
            GateSpawnFormat.Add(i, gate.name);
        }

        //Add the Relaitons
        for (int i = 0; i < NumberOfGates; i++)
        {
            LogicComponent gate = GameManager.Instance.AllGates[i];

            //Relations from the inputs of enviormentgate
            if (gate.GetType() == typeof(EnviormentGate))
            {
                for (int x = 0; x < gate.inputs.Length; x++)
                {
                    CustomNode input = gate.inputs[x] as CustomNode;
                    for (int y = 0; y < input.Links.relations.Count; y++)
                    {
                        //copy of the relations
                        List<Relation> _relation = input.Links.relations;

                        //copy form the relation gate
                        LogicComponent relationGate = _relation[y].inputNode.ownGate;

                        Debug.Log($"GateID: {i} | GateOutputID: {x}");
                        Debug.Log($"ConnectionID: {relationGate.ID} | ConnectionInputID: {_relation[y].inputNode.nodeID}");

                        int ID = i; // i is the ID from the gate
                        int IDOutput = x; // j is the ID of output node
                        int ConnectionID = relationGate.ID; // the relations gate ID
                        int ConnectionIDInput = _relation[y].inputNode.nodeID; // the connection to inputnode ID

                        Connections.Add(new Tuple<int, int, int, int>(
                            ID,
                            IDOutput,
                            ConnectionID,
                            ConnectionIDInput));
                    }
                }
            }

            //All outputs relations saving
            for (int j = 0; j < gate.outputs.Length; j++)
            {
                if (gate.GetType() == typeof(CUSTOMGate) || gate.GetType() == typeof(EnviormentGate))
                {
                    CustomNode output = gate.outputs[j] as CustomNode;
                    for (int k = 0; k < output.Links.relations.Count; k++)
                    {
                        //copy of the relations
                        List<Relation> _relation = output.Links.relations;

                        //copy form the relation gate
                        LogicComponent relationGate = _relation[k].inputNode.ownGate;

                        if (DEBUG)
                        {
                            Debug.Log($"GateID: {i} | GateOutputID: {j}");
                            Debug.Log($"ConnectionID: {relationGate.ID} | ConnectionInputID: {_relation[k].inputNode.nodeID}");
                        }

                        int ID = i; // i is the ID from the gate
                        int IDOutput = j; // j is the ID of output node
                        int ConnectionID = relationGate.ID; // the relations gate ID
                        int ConnectionIDInput = _relation[k].inputNode.nodeID; // the connection to inputnode ID

                        Connections.Add(new Tuple<int, int, int, int>(
                            ID,
                            IDOutput,
                            ConnectionID,
                            ConnectionIDInput));
                    }
                }
                else
                {
                    OutputNode output = gate.outputs[j] as OutputNode;
                    for (int k = 0; k < output.Links.relations.Count; k++)
                    {
                        //copy of the relations
                        List<Relation> _relation = (gate.outputs[j] as OutputNode).Links.relations;

                        //copy form the relation gate
                        LogicComponent relationGate = _relation[k].inputNode.ownGate;

                        if (DEBUG)
                        {
                            Debug.Log($"GateID: {i} | GateOutputID: {j}");
                            Debug.Log($"ConnectionID: {relationGate.ID} | ConnectionInputID: {_relation[k].inputNode.nodeID}");
                        }

                        int ID = i; // i is the ID from the gate
                        int IDOutput = j; // j is the ID of output node
                        int ConnectionID = relationGate.ID; // the relations gate ID
                        int ConnectionIDInput = _relation[k].inputNode.nodeID; // the connection to inputnode ID

                        Connections.Add(new Tuple<int, int, int, int>(
                            ID,
                            IDOutput,
                            ConnectionID,
                            ConnectionIDInput));
                    }
                }

                

                
            }
        }
    }
}

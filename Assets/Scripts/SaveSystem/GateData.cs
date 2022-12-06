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
    public int NumberOfGates;
    public string Name;
    public float[] rgb = new float[3];

    
    public Dictionary<int, TYPES> GateSpawnFormat = new Dictionary<int, TYPES>();
    //format <ID,Output of ID, Conneciton ID, input of connection>
    public List<Tuple<int, int, int, int>> Connections = new List<Tuple<int, int, int, int>>();

    public GateData(Enviorment env)
    {
        NumberOfGates = GameManager.Instance.AllGates.Count;
        Name = env.name;
        rgb = new float[3] { env.randomColor.r, env.randomColor.g, env.randomColor.b };


        //Add the Dictionary
        for (int i = 0; i < NumberOfGates; i++)
        {
            LogicComponent gate = GameManager.Instance.AllGates[i];
            GateSpawnFormat.Add(i, gate.Type);
        }




        //Add the Relaitons
        for (int i = 0; i < NumberOfGates; i++)
        {
            LogicComponent gate = GameManager.Instance.AllGates[i];

            for (int j = 0; j < gate.outputs.Length; j++)
            {
                OutputNode output = gate.outputs[j] as OutputNode;

                for (int k = 0; k < output.Links.relations.Count; k++)
                {
                    //copy of the relations
                    List<Relation> _relation = (gate.outputs[j] as OutputNode).Links.relations;

                    //copy form the relation gate
                    LogicComponent relationGate = _relation[j].inputNode.ownGate;

                    int ID = i; // i is the ID from the gate
                    int IDOutput = j; // j is the ID of output node
                    int ConnectionID = relationGate.ID; // the relations gate ID
                    int ConnectionIDInput = _relation[j].inputNode.nodeID; // the connection to inputnode ID

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

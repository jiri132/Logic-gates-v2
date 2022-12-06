using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic.Nodes;


namespace Logic
{
    public class CUSTOMGate : LogicComponent
    {
        [Header("Base variable")]
        public string fileName;
        public Color gateColor;


        [Header("Prefabs")]
        public NOTGate prefabNOT;
        public ANDGate prefabAND;

        [Header("SavedData")]
        public GateData DATA;
        public List<LogicComponent> AllGatesForCustomGate = new List<LogicComponent>();

        private void Start()
        {
            DATA = SaveSystem1.LoadGate(fileName);

            gateColor = new Color(DATA.rgb[0], DATA.rgb[1], DATA.rgb[2]);

            //add the gates in the order of instantiating
            for (int i = 0; i < DATA.NumberOfGates; i++)
            {
                switch (DATA.GateSpawnFormat[i])
                {
                    case TYPES.NOT:
                        LogicComponent not = this.gameObject.AddComponent(typeof(NOTGate)) as NOTGate;
                        not.Local_ID = AllGatesForCustomGate.Count;
                        AllGatesForCustomGate.Add(not);
                        break;
                    case TYPES.AND:
                        LogicComponent and = this.gameObject.AddComponent(typeof(ANDGate)) as ANDGate;
                        and.Local_ID = AllGatesForCustomGate.Count;
                        AllGatesForCustomGate.Add(and);
                        break;
                    default:
                        break;
                }
            }


            for (int i = 0; i < DATA.Connections.Count; i++)
            {
                int ID = DATA.Connections[i].Item1;
                int IDOutput = DATA.Connections[i].Item2;
                int ConnectionID = DATA.Connections[i].Item3;
                int ConnectionIDInput = DATA.Connections[i].Item4;

                OutputNode node = AllGatesForCustomGate[ID].outputs[IDOutput] as OutputNode;
                node.Links.CreateRelation(AllGatesForCustomGate[ConnectionID].inputs[ConnectionIDInput]);
            }


        }
    }
}


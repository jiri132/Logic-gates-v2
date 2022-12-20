using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Logic.Nodes;



namespace Logic
{
    public class CUSTOMGate : LogicComponent
    {
        [Header("Base variable")]
        public string fileName;
        public Color gateColor;

        private SpriteRenderer sr;
        public SpriteRenderer sr2;

        [Header("Prefabs")]
        public Transform parent;
        public GameObject prefabNOT;
        public GameObject prefabAND;
        public GameObject prefabCUSTOM;

        [Header("SavedData")]
        public GateData DATA;
        public List<LogicComponent> AllGatesForCustomGate = new List<LogicComponent>();

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
        }


        void SetData()
        {
            gateText = GetComponentInChildren<Text>();

            //load the data
            DATA = SaveSystem1.LoadGate(fileName);

            //color the gate
            gateColor = new Color(DATA.rgb[0], DATA.rgb[1], DATA.rgb[2]);
            sr.color = gateColor;
            sr2.color = gateColor * 0.4f;

            //add the gates in the order of instantiating
            for (int i = 0; i < DATA.NumberOfGates; i++)
            {
                Debug.Log(DATA.GateSpawnFormat[i]);

                switch (DATA.GateSpawnFormat[i])
                {
                    case "NOT":
                        LogicComponent not = Instantiate(prefabNOT, parent).GetComponent<NOTGate>();
                        not.isLocal = true;
                        not.Local_ID = AllGatesForCustomGate.Count;
                        AllGatesForCustomGate.Add(not);

                        break;
                    case "AND":
                        LogicComponent and = Instantiate(prefabAND, parent).GetComponent<ANDGate>();
                        and.isLocal = true;
                        and.Local_ID = AllGatesForCustomGate.Count;
                        AllGatesForCustomGate.Add(and);
                        break;
                    //when the gate is not a basic not or and gate it makes the custom gate with the correct filename
                    default:
                        prefabCUSTOM.GetComponent<CUSTOMGate>().fileName = DATA.GateSpawnFormat[i];
                        LogicComponent custom = Instantiate(prefabCUSTOM, parent).GetComponent<CUSTOMGate>();
                        custom.isLocal = true;
                        custom.Local_ID = AllGatesForCustomGate.Count;
                        AllGatesForCustomGate.Add(custom);
                        break;
                }
            }

            //rebuild the connections
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

        private void Start()
        {
            SetData();

            base.Setup(DATA.Name);
            
        }
    }
}


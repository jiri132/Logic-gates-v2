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
        public bool _DEBUG = false;

        private SpriteRenderer sr;
        public SpriteRenderer sr2;

        [Header("Prefabs")]
        public Transform parent;
        public GameObject prefabNOT;
        public GameObject prefabAND;
        public GameObject prefabCUSTOM;
        public GameObject prefabInput;
        public GameObject prefabOutput;
        public Transform inputParent;
        public Transform outputParent;


        [Header("SavedData")]
        public GateData DATA;
        public List<LogicComponent> AllGatesForCustomGate = new List<LogicComponent>();

        private void Awake()
        {
            //load the data
            DATA = SaveSystem1.LoadGate(fileName);
            sr = GetComponent<SpriteRenderer>();

            SetIO();
        }


        private void SetData()
        {
            //color the gate
            gateColor = new Color(DATA.rgb[0], DATA.rgb[1], DATA.rgb[2]);
            sr.color = gateColor;
            sr2.color = gateColor * 0.4f;

            CreateGatesUsed();

            rebuildConnections();
        }

        private void SetIO()
        {
            List<Node> nodesList = new List<Node>();

            for (int i = 0; i < DATA.NumberOfIputs; i++)
            {
                Node inputNode = Instantiate(prefabInput, inputParent).GetComponent<CustomNode>();
                inputNode.nodeID = nodesList.Count;
                nodesList.Add(inputNode);
            }
            inputs = nodesList.ToArray();
            nodesList = new List<Node>();
            for (int i = 0; i < DATA.NumberOfOutputs; i++)
            {
                Node outputNode = Instantiate(prefabOutput, outputParent).GetComponent<CustomNode>();
                outputNode.nodeID = nodesList.Count;
                nodesList.Add(outputNode);
            }
            outputs = nodesList.ToArray();
        }

        private void CreateGatesUsed()
        {
            //add the gates in the order of instantiating
            for (int i = 0; i < DATA.NumberOfGates; i++)
            {
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
                        //if it has an empty one that means it is the custom gate insides
                        if (DATA.GateSpawnFormat[i] == "") { AllGatesForCustomGate.Add(this); continue; }
                        //if (DATA.GateSpawnFormat[i] == this.fileName) { Destroy(this.gameObject); }
                        
                        //set the file name
                        prefabCUSTOM.GetComponent<CUSTOMGate>().fileName = DATA.GateSpawnFormat[i];
                        
                        //spawn the object and get logiccomponent
                        LogicComponent custom = Instantiate(prefabCUSTOM, parent).GetComponent<CUSTOMGate>();
                        //apply variables
                        custom.isLocal = true;
                        custom.Local_ID = AllGatesForCustomGate.Count;
                        AllGatesForCustomGate.Add(custom);
                        break;
                }
            }
        }

        private void rebuildConnections()
        {
            //rebuild the connections
            for (int i = 0; i < DATA.Connections.Count; i++)
            {
                int ID = DATA.Connections[i].Item1;
                int IDOutput = DATA.Connections[i].Item2;
                int ConnectionID = DATA.Connections[i].Item3;
                int ConnectionIDInput = DATA.Connections[i].Item4;

                /*if (_DEBUG)
                {
                    Debug.Log("FROM: " + ID + " |  TO: " + ConnectionID);
                    Debug.Log("Output: " + IDOutput + " |  Input: " + ConnectionIDInput);
                }*/

                LogicComponent lc = AllGatesForCustomGate[ID];

                if (lc.GetType() == typeof(CUSTOMGate))
                {
                    if (ID == 0)
                    {
                        CustomNode node = AllGatesForCustomGate[ID].inputs[IDOutput] as CustomNode;
                        node.Links.CreateRelation(AllGatesForCustomGate[ConnectionID].inputs[ConnectionIDInput]);
                    }
                    else if (ConnectionID == 0)
                    {
                        //when it has to connect to the main customgate connect to the END point
                        CustomNode node = AllGatesForCustomGate[ID].outputs[IDOutput] as CustomNode;
                        node.Links.CreateRelation(AllGatesForCustomGate[ConnectionID].outputs[ConnectionIDInput]);
                    }
                    else
                    {
/*                        if (_DEBUG)
                        {
                            Debug.Log("FROM: " + ID + " |  TO: " + ConnectionID);
                            Debug.Log("Output: " + IDOutput + " |  Input: " + ConnectionIDInput);

                            Debug.LogError("Error Need more then ID or ConnectionID");
                        }*/
                        CustomNode node = AllGatesForCustomGate[ID].outputs[IDOutput] as CustomNode;
                        node.Links.CreateRelation(AllGatesForCustomGate[ConnectionID].inputs[ConnectionIDInput]);
                    }
                }
                else
                {
                    if (ConnectionID == 0)
                    {
                        OutputNode node = AllGatesForCustomGate[ID].outputs[IDOutput] as OutputNode;
                        node.Links.CreateRelation(AllGatesForCustomGate[ConnectionID].outputs[ConnectionIDInput]);
                    }
                    else
                    {
                        OutputNode node = AllGatesForCustomGate[ID].outputs[IDOutput] as OutputNode;
                        node.Links.CreateRelation(AllGatesForCustomGate[ConnectionID].inputs[ConnectionIDInput]);
                    }
                }
            }
        } 


        private void Start()
        {
            SetData();

            gateText = GetComponentInChildren<Text>();

            base.Setup(DATA.Name);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic.Nodes
{
    public class CustomNode : Node
    {
        [Header("Relations")]
        public LogicLink Links;

        private void Awake()
        {
            Links.self = this;
        }

        public override void _transferdata()
        {
            if (state == 1) { Links.Trigger(true); }
            else { Links.Trigger(false); }
        }

        public void OnMouseOver()
        {
            if (Type == NodeType.CustomOutput)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Wire other = GameManager.Instance.selectedWire;

                    if (CanConnect(other.OutputNode))
                    {
                        //link the nodes together
                        OutputNode otherNode = (OutputNode)other.OutputNode;
                        otherNode.Links.CreateRelation(this);
                        Wires.Add(other);

                        //make th wie to the other node
                        other.InputNode = this;
                    }
                }
            }else if (Type == NodeType.CustomInput)
            {
                //return the function if it is input of the already custom created gate
                if (onGate == true) { return; }

                if (Input.GetMouseButtonDown(0))
                {
                    //instantie and get the wire component
                    Wire wire = Instantiate(LogicSettings.Instance.wirePrefab, this.transform.position, Quaternion.identity, this.transform).GetComponent<Wire>();

                    //give all the things wire needs and gamemanager
                    wire.OutputNode = this;
                    GameManager.Instance.selectedWire = wire;
                    Wires.Add(wire);
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    if (!onGate && Input.GetMouseButtonDown(1)) { if (state == 1) { state = 0; } else { state = 1; } }
                }
                else if (Input.GetMouseButtonDown(2))
                {
                    foreach (Wire wire in Wires.ToArray())
                    {
                        Destroy(wire.gameObject);
                        Wires.Remove(wire);
                    }
                    Links.relations = new List<Relation>();
                }
            } 
        }

        public override void UpdateWirePositions()
        {
            foreach (Wire wire in Wires)
            {
                wire.SetPosition(wire.GetPositionCount() - 1, transform.position);
            }
        }
    }
    
}
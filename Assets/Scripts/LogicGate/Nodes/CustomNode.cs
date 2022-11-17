using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic.Nodes
{
    public class CustomNode : Node
    {
        [Header("Relations")]
        public LogicLink Links;

        public override void OnMouseDown()
        {

            if (Type == NodeType.Output)
            {
                if (!Input.GetMouseButtonDown(0)) { Destroy(GameManager.Instance.selectedWire); return; }

                Wire other = GameManager.Instance.selectedWire;

                if (CanConnect(other.OutputNode))
                {
                    //link the nodes together
                    OutputNode otherNode = (OutputNode)other.OutputNode;
                    otherNode.Links.CreateRelation(this);
                    Wires.Add(other);
                    //mkae th wie to the other node
                    other.InputNode = this;
                }
                return;
            } 


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
                foreach (Wire wire in Wires.ToArray())
                {
                    Destroy(wire.gameObject);
                    Wires.Remove(wire);
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
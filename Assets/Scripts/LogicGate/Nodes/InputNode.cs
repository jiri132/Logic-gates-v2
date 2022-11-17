using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic.Nodes
{
    public class InputNode : Node
    {
        public override void OnMouseDown()
        {
            

            //early return if it is not left mouse input and destroy the wire
            //if (!Input.GetMouseButtonDown(0)) { Destroy(GameManager.Instance.selectedWire); return; }

            Wire other = GameManager.Instance.selectedWire;

            if (CanConnect(other.OutputNode))
            {
                //link the nodes together
                OutputNode otherNode = (OutputNode)other.OutputNode;
                otherNode.Links.CreateRelation(this);
                Wires.Add(other);
                GameManager.Instance.selectedWire = null;
                //mkae th wie to the other node
                other.InputNode = this;
            }
        }

        public override void UpdateWirePositions()
        {
            foreach (Wire wire in Wires)
            {
                wire.SetPosition(wire.GetPositionCount() - 1, transform.position);
            }
        }



        /*public override void Start()
        {
            base.Type = NodeType.Input;
        }*/
    }
}

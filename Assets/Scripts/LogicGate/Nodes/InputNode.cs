using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic.Nodes
{
    public class InputNode : Node
    {
        public void OnMouseOver()
        {
            if (!Input.GetMouseButtonDown(0)) { return; }

            if (GameManager.Instance.selectedWire == null) { return; }

            Wire other = GameManager.Instance.selectedWire;

            if (CanConnect(other.OutputNode))
            {
                //link the nodes together

                if (other.OutputNode.GetType() == typeof(CustomNode))
                {
                    //get the correct node cast
                    CustomNode otherNode = (CustomNode)other.OutputNode;
                    otherNode.Links.CreateRelation(this);
                    Wires.Add(other);
                    GameManager.Instance.selectedWire = null;
                    //make the wire to the other node
                    other.InputNode = this;
                }
                else
                {
                    //get the correct node cast
                    OutputNode otherNode = (OutputNode)other.OutputNode;
                    otherNode.Links.CreateRelation(this);
                    Wires.Add(other);
                    GameManager.Instance.selectedWire = null;
                    //make the wire to the other node
                    other.InputNode = this;
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

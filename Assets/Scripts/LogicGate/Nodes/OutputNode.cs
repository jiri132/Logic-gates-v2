using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic.Nodes
{
    public class OutputNode : Node
    {
        [Header("Relations")]
        public LogicLink Links;

        private void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0))
            {
                //instantie and get the wire component
                Wire wire = Instantiate(LogicSettings.Instance.wirePrefab, this.transform.position, Quaternion.identity, this.transform).GetComponent<Wire>();

                //give all the things wire needs and gamemanager
                wire.OutputNode = this;
                GameManager.Instance.selectedWire = wire;
                Wires.Add(wire);
            }
            else if (Input.GetMouseButtonDown(2))
            {
                foreach (Wire wire in Wires.ToArray())
                {
                    wire.InputNode._state = 0;
                    wire.InputNode.UpdateUI();
                    wire.InputNode.Wires.Remove(wire);
                    Wires.Remove(wire);
                    Destroy(wire.gameObject);
                }
            }

        }

        public override void UpdateWirePositions()
        {
            foreach (Wire wire in Wires)
            {
                wire.SetPosition(0, transform.position);
            }
        }

        public override void _transferdata()
        {
            if (state == 1) { Links.Trigger(true); }
            else { Links.Trigger(false); }
        }

        private void Awake()
        {
            Links.self = this;
        }
    }
}

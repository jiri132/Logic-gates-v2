using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO: add the function of datatransfer

namespace Logic.Nodes
{
    public class OutputNode : Node
    {
        [Header("Relations")]
        public LogicLink Links;
            
        public override void OnMouseDown()
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
            else if (Input.GetMouseButtonDown(1))
            {
                foreach (Wire wire in Wires.ToArray())
                {
                    Destroy(wire.gameObject);
                    Wires.Remove(wire);
                }
            }
        }

        public override void Start()
        {
            base.Type = NodeType.Output;
            Links.self = this;
        }
    }
}

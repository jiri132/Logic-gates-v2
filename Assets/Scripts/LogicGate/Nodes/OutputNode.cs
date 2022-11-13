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
                GameObject go = Instantiate(LogicSettings.Instance.wirePrefab, this.transform.position, Quaternion.identity, this.transform);
                Wire wire = go.GetComponent<Wire>();
                wire.OutputNode = this;
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

        private void Start()
        {
            base.Type = NodeType.Output;
        }
    }
}

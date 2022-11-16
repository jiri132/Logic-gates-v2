using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic.Nodes
{
    public abstract class Node : MonoBehaviour
    {
        [Header("Node Type")]
        public NodeType Type;

        [Header("Node State")]
        [SerializeField] private byte _state;
        public byte state
        {
            get { return _state; }
            set
            {
                if (value == _state) { return; }

                _state = value;
                UpdateUI();
                if (Type == NodeType.Input) { Invoke("_propegation", LogicSettings.Instance.interval); }
                else if (Type == NodeType.Output) { Invoke("_transferdata", LogicSettings.Instance.interval); }
            }
        }
        [Header("Node UI")]
        public SpriteRenderer nodeUI;

        [Header("Node Wires")]
        public List<Wire> Wires;

        [Header("Nodes Parent")]
        private LogicComponent ownGate;

        public void Start()
        {
            nodeUI = this.GetComponent<SpriteRenderer>();
            ownGate = this.GetComponentInParent<LogicComponent>();
        }

        private void _propegation() => ownGate.Propegation();

        public virtual void _transferdata() { }

        public virtual void UpdateUI()
        {
            if (state == 1) 
            {
                nodeUI.color = LogicSettings.Instance.onColor;
                foreach (Wire wire in Wires)
                {
                    wire.UpdateUI(LogicSettings.Instance.onColor);
                }
                return; 
            }
            foreach (Wire wire in Wires)
            {
                wire.UpdateUI(LogicSettings.Instance.offColor);
            }
            nodeUI.color = LogicSettings.Instance.offColor;
        }

        #region Wire Functions

        public bool CanConnect(Node other)
        {
            //if the node type is the same it can't connect
            if (this.Type == other.Type) { return false; }
            return true;
        }

        #endregion


        #region Abstracts

        //wire spawning
        public abstract void OnMouseDown();

        #endregion
    }
}

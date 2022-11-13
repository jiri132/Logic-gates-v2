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

            }
        }
        [Header("Node UI")]
        public SpriteRenderer nodeUI;

        [Header("Node Wires")]
        public List<Wire> Wires;

        private void Start()
        {
            nodeUI = this.GetComponent<SpriteRenderer>();
        }


        public void UpdateUI()
        {
            if (state == 1) { nodeUI.color = LogicSettings.Instance.onColor; return; }
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

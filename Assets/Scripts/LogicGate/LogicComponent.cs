using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Logic.Nodes;

namespace Logic
{
    public abstract class LogicComponent : DragAndDrop<LogicComponent>
    {
        #region Base Variables
        [Header("Basic Information")]
        public TYPES Type;
        public int ID;
        public bool isLocal = false;
        public int Local_ID;

        [Header("LogicGate Name")]
        public new string name;
        public Text gateText;

        [Header("Internal Data")]
        [SerializeField] private Node[] _inputs;
        public Node[] inputs
        {
            get { return _inputs; }
            protected set
            {
                _inputs = value;
            }
        }

        [SerializeField] private Node[] _outputs;
        public Node[] outputs
        {
            get { return _outputs; }
            protected set
            {
                _outputs = value;
            }
        }

        #endregion

        #region Abstracts

        public virtual void Propegation() { }
       
        #endregion

        #region Setups
        /// <summary>
        /// just the basic setup to be completed when waking up the script
        /// </summary>
        /// <param name="name">logic gate name</param>
        public void Setup(string name)
        {
            NameSetup(name);
            
            if (Type != TYPES.CUSTOM)
                Invoke("Propegation", LogicSettings.Instance.interval);

            if (!isLocal)
            {
                this.ID = GameManager.Instance.AllGates.Count;
                GameManager.Instance.AllGates.Add(this);
            }
        }

        private void NameSetup(string name)
        {
            this.name = name;

            if (gateText != null) { gateText.text = name; }
        }
        #endregion
        #region Reusable Functions
        public byte[] GetAllInputData()
        {
            byte[] data = new byte[inputs.Length];
            int i = 0;
            foreach (Node inputNode in inputs)
            {
                data[i] = inputNode.state;
                i++;
            }
            return data;
        }
        public void SetInput(byte[] data)
        {
            int i = 0;
            foreach (Node inputNode in inputs)
            {
                inputNode.state = data[i];
                i++;
            }
        }

        public void SetID(int ID)
        {
            this.ID = ID;
        }

        #endregion
    }
}
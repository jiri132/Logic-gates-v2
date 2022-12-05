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
        public int ID { get; private set; }


        [Header("LogicGate Name")]
        public new string name;

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

        public abstract void Propegation();
       
        #endregion

        #region Setups
        /// <summary>
        /// just the basic setup to be completed when waking up the script
        /// </summary>
        /// <param name="name">logic gate name</param>
        /// <param name="self">it self</param>
        /// <param name="inputs">the total input nodes</param>
        /// <param name="outputs">the total output nodes</param>
        public virtual void Setup(string name)
        {
            NameSetup(name);
            this.ID = GameManager.Instance.AllGates.Count;

            Invoke("Propegation", LogicSettings.Instance.interval);
        }

        private void NameSetup(string name)
        {
            this.name = name;
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

        #endregion



    }
}
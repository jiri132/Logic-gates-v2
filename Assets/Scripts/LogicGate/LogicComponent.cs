using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Logic.Nodes;

namespace Logic
{
    public abstract class LogicComponent : MonoBehaviour
    {
        #region Base Variables
        //used in old system
        //public abstract TYPES GetLogicType();

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

                //Invoke("Propegation", LogicSettings.Instance.interval);
            }
        }

        [SerializeField] private Node[] _outputs;
        public Node[] outputs
        {
            get { return _outputs; }
            protected set
            {
                _outputs = value;

                //Invoke("TransferData", LogicSettings.Instance.interval);
            }
        }

        #endregion

        private void TransferData()
        {
            for (int i = 0; i < outputs.Length; i++)
            {
                //if an output is active send a notification to the relation else also sent notification
                //if (outputs[i] == 1) { bridge.links[i].Trigger(true); }
                //else { bridge.links[i].Trigger(false); }
            }
            SetNodes();
            //UpdateUI();
        }

        protected void SetNodes()
        {
            
        }

        #region Abstracts

        public virtual void Propegation() { }
       
        #endregion

        #region Virtuals



        #region Setups
        /// <summary>
        /// just the basic setup to be completed when waking up the script
        /// </summary>
        /// <param name="name">logic gate name</param>
        /// <param name="self">it self</param>
        /// <param name="inputs">the total input nodes</param>
        /// <param name="outputs">the total output nodes</param>
        public virtual void Setup(string name, LogicComponent self, byte[] inputs, byte[] outputs)
        {
            NameSetup(name);
            IOSetup(inputs,outputs);

            Invoke("Propegation", 1f);
        }

        //TODO: Revamp the IOSetup function
        /// <summary>
        /// this is the hardcoded setup for inputs and outputs
        /// </summary>
        /// <param name="inputs">output nodes</param>
        /// <param name="outputs">input nodes</param>
        public virtual void IOSetup(byte[] inputs, byte[] outputs)
        {
           /* _inputs = new Node[inputs.Length];
            _outputs = new Node[outputs.Length];*/
        }


        public virtual void NameSetup(string name)
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
        public virtual void SetInput(byte[] data)
        {
            int i = 0;
            foreach (Node inputNode in inputs)
            {
                inputNode.state = data[i];
                i++;
            }
        }

        #endregion

        #endregion


    }
}
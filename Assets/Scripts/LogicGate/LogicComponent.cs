using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public abstract class LogicComponent : MonoBehaviour
    {
        #region Base Variables
        //used in old system
        //public abstract TYPES GetLogicType();

        [Header("LogicGate Name")]
        public new string name;

        [Header("Linking Bridge")]
        [SerializeField]
        public LogicBridge bridge;

        [Header("Internal Data")]
        [SerializeField]
        private byte[] _inputs = new byte[1] { 0 };
        public byte[] inputs
        {
            get { return _inputs; }
            set
            {
                //guard clause to stop it if its the  same value
                if (value == _inputs) { return; }

                _inputs = value;
            }
        }
        [SerializeField]
        private byte[] _outputs = new byte[1] { 0 };
        public byte[] outputs
        {
            get { return _outputs; }
            set
            {
                //guard clause to stop it if its the  same value
                if (value == _outputs) { return; }

                _outputs = value;
            }
        }

        #endregion

        #region Abstracts

        public abstract void Start();
        public abstract void Propegate();

        #endregion

        #region Virtuals

        /// <summary>
        /// just the basic setup to be completed when waking up the script
        /// </summary>
        /// <param name="name">logic gate name</param>
        /// <param name="gate">it self</param>
        /// <param name="inputs">the total input nodes</param>
        /// <param name="outputs">the total output nodes</param>
        public virtual void Setup(string name, LogicComponent gate, byte[] inputs, byte[] outputs)
        {
            NameSetup(name);
            IOSetup(inputs,outputs);
            BridgeSetup(gate);
        }

        /// <summary>
        /// this is the hardcoded setup for inputs and outputs
        /// </summary>
        /// <param name="inputs">output nodes</param>
        /// <param name="outputs">input nodes</param>
        public virtual void IOSetup(byte[] inputs, byte[] outputs)
        {
            _inputs = inputs;
            _outputs = outputs;
        }

        /// <summary>
        /// This is the base setup for having the brigde open and set to go
        /// </summary>
        /// <param name="gate">Him self</param>
        /// <param name="name">The name of the gate</param>
        public virtual void BridgeSetup(LogicComponent gate)
        {
            this.bridge._self = gate;

            if (bridge.links.Length == 0 || bridge.links.Length > outputs.Length) { bridge.links = new LogicLink[outputs.Length]; }

            foreach (LogicLink link in bridge.links)
            {
                link.AddSelf(gate);
            }

        }

        public virtual void NameSetup(string name)
        {
            this.name = name;
        }



        #endregion


    }
}
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
                Invoke("OutputPropegation", 1f);
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

                List<byte> indexesChanged = new List<byte>();
                
                for (byte i = 0; i < _outputs.Length; i++)
                {
                    if (_outputs[i] != value[i]) { indexesChanged.Add(i); }
                }
                
                _outputs = value;

                for (byte i = 0; i < indexesChanged.Count; i++)
                {
                    bridge.links[i].Trigger(InputPropegation());
                }
            }
        }

        #endregion

        #region Abstracts

        public abstract void Start();

        /// <summary>
        /// used to know what the input nodes are going to be
        /// </summary>
        public abstract bool InputPropegation();

        /// <summary>
        /// used to know what the output nodes are going to be
        /// </summary>
        public abstract void OutputPropegation();
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
            BridgeSetup(self);

            OutputPropegation();
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
        /// <param name="self">Him self</param>
        /// <param name="name">The name of the gate</param>
        public virtual void BridgeSetup(LogicComponent self)
        {
            this.bridge._self = self;

            if (bridge.links.Length == 0 || bridge.links.Length > outputs.Length) { bridge.links = new LogicLink[outputs.Length]; }

            for (int i = 0; i < bridge.links.Length; i++)
            {
                bridge.links[i] = new LogicLink(self,i);
            }
        }

        public virtual void NameSetup(string name)
        {
            this.name = name;
        }
        #endregion
        #region Reusable Functions

        public virtual void SetVariable(byte[] variable, int variableLenght, byte[] data)
        {
            variable = new byte[variableLenght];
            variable = data;
        }

        #endregion

        #endregion


    }
}
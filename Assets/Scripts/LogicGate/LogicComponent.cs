using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            protected set
            {
                _inputs = value;

                Invoke("Propegation", LogicSettings.Instance.interval);
            }
        }
        [SerializeField]
        private byte[] _outputs = new byte[1] { 0 };
        public byte[] outputs
        {
            get { return _outputs; }
            protected set
            {
                _outputs = value;

                Invoke("TransferData", LogicSettings.Instance.interval);
            }
        }

        #endregion
        #region UI variables

        [Header("IO UI")]
        public SpriteRenderer[] inputRenders;
        public SpriteRenderer[] outputRenders;

        #endregion

        private void TransferData()
        {
            for (int i = 0; i < outputs.Length; i++)
            {
                //if an output is active send a notification to the relation else also sent notification
                if (outputs[i] == 1) { bridge.links[i].Trigger(true); }
                else { bridge.links[i].Trigger(false); }
            }
            UpdateUI();


        }

        public void UpdateUI()
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                if(inputs[i] == 1)
                {
                    inputRenders[i].color = LogicSettings.Instance.onColor;
                    continue;
                }
                inputRenders[i].color = LogicSettings.Instance.offColor;
            }
            for (int i = 0; i < outputs.Length; i++)
            {
                if (outputs[i] == 1)
                {
                    outputRenders[i].color = LogicSettings.Instance.onColor;
                    continue;
                }
                outputRenders[i].color = LogicSettings.Instance.offColor;
            }
        }

        #region Abstracts

        public virtual void Propegation() { UpdateUI(); }
       
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

            Invoke("Propegation", 1f);
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

        public virtual void SetInput(byte[] data)
        {
            inputs = data;
        }

        #endregion

        #endregion


    }
}
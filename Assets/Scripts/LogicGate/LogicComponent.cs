using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public abstract class LogicComponent : MonoBehaviour
    {
        //usefd in old system
        //public abstract TYPES GetLogicType();

        [Header("LogicGate Name")]
        public new string name;

        [Header("Linking Bridge")]
        [SerializeField]
        public LogicBridge bridge;

        [Header("Internal Data")]
        [SerializeField]
        private int[] _inputs = new int[1] { 0 };
        public int[] inputs
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
        private int[] _outputs = new int[1] { 0 };
        public int[] outputs
        {
            get { return _outputs; }
            set
            {
                //guard clause to stop it if its the  same value
                if (value == _outputs) { return; }

                _outputs = value;
            }
        }

        /* placed Inputs and outputs right here so function aren't needed anymore
         * to acces them in the custom classes use base.<variable>
         * public abstract int[] GetInputData();
         * public abstract int[] GetOutputData();
         * public abstract void SetInputData(int[] data);
         * public abstract void SetInputData(int data,int index);
         */

        public abstract void Start();
        public abstract void Propegate();
        /// <summary>
        /// this is the hardcoded setup for inputs and outputs
        /// </summary>
        /// <param name="inputs">output nodes</param>
        /// <param name="outputs">input nodes</param>
        public virtual void IOSetup(int[] inputs, int[] outputs)
        {
            _inputs = inputs;
            _outputs = outputs;
        }
        /// <summary>
        /// This is the base setup for having the brigde open and set to go
        /// </summary>
        /// <param name="gate">Him self</param>
        /// <param name="name">The name of the gate</param>
        public virtual void BridgeSetup(LogicComponent gate, string name)
        {
            this.name = name;
            this.bridge._self = gate;

            if (bridge.links.Length == 0) { bridge.links = new LogicLink[outputs.Length]; }

            for (int i = 0; i < bridge.links.Length; i++)
            {
                bridge.links[i]._self = gate;
            }
        }

    }
}
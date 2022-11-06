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
        public string name;

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
    }
}
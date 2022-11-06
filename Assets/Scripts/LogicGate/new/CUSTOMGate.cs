using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class CUSTOMGate : LogicComponent
    {
        #region Constructor

        public CUSTOMGate(int inputs, int outputs, string name)
        {
            base.name = name;
            base.inputs = new int[inputs];
            base.outputs = new int[outputs];
            base.bridge._self = this;
            base.bridge.links = new LogicLink[outputs];
        }

        #endregion

        #region Variables


        public override void Propegate()
        {

        }

        #endregion

        #region Overrides Of Component
        private void Awake()
        {
            base.Setup(this, "CUSTOM");
        }

        public override void Start()
        {
            /*for (int i = 0; i < link.Length; i++)
            {
                link[i]._self = this;
                link[i]._outputIndex = i;
            }*/
        }
        #endregion
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class ANDGate : LogicComponent
    {
        #region Variables



        #endregion

        public void Start()
        {

        }

        #region Overrides Of Component

        private void Awake()
        {
            base.Setup("AND",this,new byte[2],new byte[1]);
        }

        public override void Propegation()
        {
            if ((base.inputs[0] == 1 && base.inputs[1] == 1) && outputs[0] != 1) { base.outputs = new byte[1] { 1 }; }
            else if (outputs[0] != 0) { base.outputs = new byte[1] { 0 }; }
        }

        #endregion
    }
}
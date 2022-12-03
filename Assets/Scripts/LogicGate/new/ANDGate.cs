using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class ANDGate : LogicComponent
    {
        #region Overrides Of Component
        private void Awake()
        {
            base.NameSetup("AND");
            Invoke("Propegation", LogicSettings.Instance.interval);
            //base.Setup("AND",this,new byte[2],new byte[1]);
        }

        public override void Propegation()
        {
            if ((base.inputs[0].state == 1 && base.inputs[1].state == 1) && outputs[0].state == 0) { base.outputs[0].state = 1; }
            else if (outputs[0].state != 0 && (base.inputs[0].state != 1 || base.inputs[1].state != 1)) { base.outputs[0].state = 0; }
        }
        #endregion
    }
}
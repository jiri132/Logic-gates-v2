using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class NOTGate : LogicComponent
    {
        #region Overrides Of Component
        private void Awake()
        {
            if (isLocal) { return; }

            base.Setup("AND");
            GameManager.Instance.AllGates.Add(this);
        }

        public override void Propegation()
        {
            if (inputs[0].state == 0 && outputs[0].state != 1) { outputs[0].state = 1; }
            else if (inputs[0].state != 0 && outputs[0].state != 0) { outputs[0].state = 0; }    
        }
        #endregion
    }
}
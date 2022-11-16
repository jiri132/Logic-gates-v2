using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class NOTGate : LogicComponent
    {
        #region Variables

        #endregion

        public void Start()
        {

        }

        #region Overrides Of Component

        private void Awake()
        {
            base.NameSetup("AND");
            Invoke("Propegation", LogicSettings.Instance.interval);
            //base.Setup("NOT", this, new byte[1], new byte[1]);
            //bridge.links[0].CreateRelation(this, 0);
        }

       
        public override void Propegation()
        {
            if (inputs[0].state == 0 && outputs[0].state != 1) { outputs[0].state = 1; }
            else if (inputs[0].state != 0 && outputs[0].state != 0) { outputs[0].state = 0; }    
        }

        #endregion
    }
}
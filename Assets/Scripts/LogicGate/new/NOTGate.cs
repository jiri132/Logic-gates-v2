using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class NOTGate : LogicComponent
    {
        #region Variables

        #endregion

        public override void Propegate()
        {
           
        }


        #region Overrides Of Component
        private void Awake()
        {
            base.BridgeSetup(this, "NOT");
        }

        public override void Start()
        {
            
        }

        #endregion
    }
}


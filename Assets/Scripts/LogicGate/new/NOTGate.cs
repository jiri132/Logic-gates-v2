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
            Debug.Log($"Propegating{base.name}");
            if (base.inputs[0] == 1) { base.outputs = new byte[1] { 0 }; }
            else { base.outputs = new byte[1] { 1 }; }
        }


        #region Overrides Of Component
        private void Awake()
        {
            base.Setup("NOT", this, new byte[1], new byte[1]);
            bridge.links[0].CreateRelation(this, 0);
        }

        public override void Start()
        {

        }

        #endregion
    }
}


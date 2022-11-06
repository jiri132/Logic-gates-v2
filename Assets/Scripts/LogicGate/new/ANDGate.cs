using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class ANDGate : LogicComponent
    {
        #region Variables



        #endregion
        public override void Propegate()
        {

        }

        #region Overrides Of Component

        private void Awake()
        {
            base.Setup("AND",this,new byte[2],new byte[1]);
        }

        public override void Start()
        {
           

        }
        #endregion
    }
}


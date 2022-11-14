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
           // base.outputs = new byte[outputs];
        }

        #endregion

        #region Variables



        #endregion

        public void Start()
        {
            /*for (int i = 0; i < link.Length; i++)
            {
                link[i]._self = this;
                link[i]._outputIndex = i;
            }*/
        }

        #region Overrides Of Component

        private void Awake()
        {
            //TODO: make a save system for custom gates data
            //base.Setup("CUSTOM",this,);
        }

        public override void Propegation()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}


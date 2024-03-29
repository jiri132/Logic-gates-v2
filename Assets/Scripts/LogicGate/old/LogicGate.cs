﻿/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extentions.Observables;

namespace Logic 
{
    public class LogicGate : LogicComponent
    {
        #region Constructors
        private LogicGate(int[] inputs, int[] outputs)
        {
            _inputs = inputs;
            _outputs = outputs;
        }
        #endregion

        #region Variables
        [Header("Linking bridge")]
        [SerializeField]private List<LogicLink> link;

        [Header("Gate Type")]
        [SerializeField]private TYPES _type;

        [Header("Internal Data")]

        [SerializeField] private int[] _inputs;
        public new int[] inputs
        {
            get { return _inputs; }
            protected set
            {
                _inputs = value;
                // ADD function calls here
                //Activation();
                Invoke("_Propegation", 0.1f);
            }
        }

        [SerializeField]private int[] _outputs;

        public new int[] outputs
        {
            get { return _outputs; }
            protected set
            {
                _outputs = value;
                // ADD function calls here
                //LinkDataTransfer();
                Invoke("TransferData", 0.1f);
            }
        }
        
        #endregion

        public void Start()
        {
            _outputs = new int[1] { 0 };
            //if the input gets selected 
            _inputs = _type == TYPES.NOT ? new int[1] { 0 } : new int[2] { 0 , 0 };

            //make al lthe link modules connected to each output node
            for (int i = 0; i < _outputs.Length; i++)
            {
                //link.Add(new LogicLink(i));
            }
            link[0].CreateRelation();
            Invoke("_Propegation", 1f);
        }

        /// <summary>
        /// Checks if it can activate based on the logic gate it is
        /// </summary>
        void _Propegation()
        {
            Debug.Log("Activation");
            switch (_type)
            {
                case TYPES.NOT:
                    if (inputs[0] == 0 && outputs[0] != 1) { outputs = new int[1] { 1 }; }
                    else if (outputs[0] != 0) { outputs = new int[1] { 0 }; }
                    break;
                case TYPES.AND:
                    if ((inputs[0] == 1 && inputs[1] == 1) && outputs[0] != 1) { outputs = new int[1] { 1 }; } 
                    else if (outputs[0] != 0) { outputs = new int[1] { 0 }; }
                    break;
                case TYPES.CUSTOM:
                    
                    break;
                default:
                    break;
            }
        }
        void TransferData()
        {
            Debug.Log("link data");
            //loop through all the outputs 
            for (int i = 0; i < outputs.Length; i++)
            {
                //if an output is active send a notification to the relation else also sent notification
                if (outputs[i] == 1) { link[i].Trigger(true); }
                else { link[i].Trigger(false); }
            }
        }

        #region Overrides of Component

       //* public override TYPES GetLogicType()
        
          

        public override void Propegation()
        {
            throw new System.NotImplementedException();
        }

        
        public int[] GetInputData() => inputs;
       

        public int[] GetOutputData() => outputs;
        
        public void SetInputData(int[] data)
        {
            inputs = data;
            //Invoke("Activation", 1f);
        }
        public void SetInputData(int data, int index)
        {
            inputs[index] = data;
            //Invoke("Activation", 1f);
        }
      


        #endregion
    }
}
*/
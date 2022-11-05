using System.Collections;
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
        [SerializeField]private int[] _outputs = new int[1] { 0 };

        public int[] outputs
        {
            get { return _outputs; }
            protected set
            {
                _outputs = value;
                // ADD function calls here
                Invoke("LinkDataTransfer", 0.2f);
            }
        }
        [SerializeField]private int[] _inputs;
        public int[] inputs
        {
            get { return _inputs; }
            protected set
            {
                _inputs = value;
                // ADD function calls here
                Activation();
                Invoke("Activation", 0.2f);
            }
        }
        #endregion

        public override void Start()
        {
            _outputs = new int[1] { 0 };
            //if the input gets selected 
            _inputs = _type == TYPES.NOT ? new int[1] { 0 } : new int[2] { 0 , 0 };

            //make al lthe link modules connected to each output node
            for (int i = 0; i < _outputs.Length; i++)
            {
                link.Add(new LogicLink(this, i));
            }
            link[0].CreateRelation(this,0);
            Activation();
        }

        /// <summary>
        /// Checks if it can activate based on the logic gate it is
        /// </summary>
        void Activation()
        {
            int[] data = new int[1] { 1 };
            Debug.Log("Activation");
            switch (_type)
            {
                case TYPES.NOT:
                    if (inputs[0] == 0) { outputs = data; }
                    else { outputs[0] = data[0] = 0; }
                    break;
                case TYPES.AND:
                    if (inputs[0] == 1 && inputs[1] == 1) { outputs = data; } 
                    else { outputs[0] = data[0] = 0; }
                    break;
                case TYPES.OR:
                    if (inputs[0] == 1 || inputs[1] == 1) { outputs = data; } 
                    else { outputs[0] = data[0] = 0; }
                    break;
                case TYPES.CUSTOM:
                    
                    break;
                default:
                    break;
            }
        }
        void LinkDataTransfer()
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

        public override TYPES GetLogicType()
        {
            return _type;
        }
        public override int[] GetInputData() => inputs;
       

        public override int[] GetOutputData() => outputs;
        
        public override void SetInputData(int[] data)
        {
            inputs = data;
            Activation();
        }
        public override void SetInputData(int data, int index)
        {
            inputs[index] = data;
            Activation();
        }


        #endregion
    }
}

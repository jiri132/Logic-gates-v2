using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public LogicLink links;

        [SerializeField]private TYPES _type;
        private int[] _outputs = new int[1] { 0 };

        public int[] outputs
        {
            get { return _outputs; }
            set
            {
                _outputs = value;
                // ADD function calls here
            }
        }
        private int[] _inputs;
        public int[] inputs
        {
            get { return _inputs; }
            set
            {
                _inputs = value;
                // ADD function calls here
            }
        }
        #endregion

        public override void Start()
        {
            //if the input gets selected 
            _inputs = _type == TYPES.NOT ? new int[1] { 0 } : new int[2] { 0 , 0 };
        }

        #region Overrides of Component

        public override TYPES GetLogicType()
        {
            return _type;
        }
        public override int[] GetInputsData()
        {
            return inputs;
        }

        public override int[] GetOutputsData()
        {
            return outputs;
        }

        
        #endregion
    }
}

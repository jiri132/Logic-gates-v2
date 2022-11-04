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
        [Header("Linking bridge")]
        [SerializeField]private List<LogicLink> link;

        [Header("Gate Type")]
        [SerializeField]private TYPES _type;

        [Header("Internal Data")]
        [SerializeField]private int[] _outputs = new int[1] { 0 };

        public int[] outputs
        {
            get { return _outputs; }
            set
            {
                _outputs = value;
                // ADD function calls here
            }
        }
        [SerializeField]private int[] _inputs;
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
            _outputs = new int[1] { 0 };
            //if the input gets selected 
            _inputs = _type == TYPES.NOT ? new int[1] { 0 } : new int[2] { 0 , 0 };

            //make al lthe link modules connected to each output node
            for (int i = 0; i < _outputs.Length; i++)
            {
                link.Add(new LogicLink(this, i));
            }
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

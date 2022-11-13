using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    [System.Serializable]
    public class LogicLink
    {
        [Header("Link Modules Owner")]
        [HideInInspector]
        public LogicComponent _self;
        public int _outputIndex;

        //TODO: relations act when the _self is active but relation is not set before activation
        [Header("Links to Others")]
        public List<Relation> relations = new List<Relation>();

        public LogicLink(LogicComponent _self,int _outputIndex)
        {
            //create the object
            this._self = _self;
            this._outputIndex = _outputIndex;
        }

        public void AddSelf(LogicComponent _self)
        {
            this._self = _self;
        }

        //based on the powered notification switch on or off the input
        public void Trigger(bool powered)
        {
            foreach (Relation relation in relations)
            {
                int index = relation._inputIndex;
                LogicComponent relation_gate = relation._gate;

                //get the whole data set and change only the needed index
                byte[] data = relation._gate.inputs;
                data[index] = powered == true ? (byte)1 : (byte)0;
                
                //set all the data back as new and fire off the activation function
                relation_gate.SetInput(data);
            }
        }

        public void CreateRelation(LogicComponent other, int index)
        {
            relations.Add(new Relation(other, index));

            //acts as an Observable when connecting
            if (_self.outputs[_outputIndex] == 1)
            {
                other.inputs[index] = 1;
            }
        }
    }

    [System.Serializable]
    public class Relation
    {
        [Header("Others Information")]
        public LogicComponent _gate;
        public int _inputIndex;

        public Relation(LogicComponent relation, int index)
        {
            _gate = relation;
            _inputIndex = index;
        }
    }

}


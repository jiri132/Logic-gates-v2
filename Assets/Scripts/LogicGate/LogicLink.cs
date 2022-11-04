using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extentions.List;

namespace Logic
{
    [System.Serializable]
    public class LogicLink
    {
        [Header("Link Modules Owner")]
        public LogicGate _self;
        public int _outputIndex;

        //TODO: relations act when the _self is active but relation is not set before activation
        [Header("Links to Others")]
        public List<Relation> relations; 
        
        public LogicLink(LogicGate _self,int _outputIndex)
        {
            //create the object
            this._self = _self;
            this._outputIndex = _outputIndex;

            //create the list of relations
            relations = new List<Relation>();
        }

        //based on the powered notification switch on or off the input
        public void Trigger(bool powered)
        {
            foreach (Relation relation in relations)
            {
                int index = relation._inputIndex;
                LogicGate relation_gate = relation._gate;

                //get the whole data set and change only the needed index
                int[] data = relation._gate.inputs;
                data[index] = powered == true ? 1 : 0;

                //set all the data back as new and fire off the activation function
                relation_gate.SetInputData(data);
            }
        }

        public void CreateRelation(LogicGate other, int index)
        {
            relations.Add(new Relation(other, index));
        }
    }

    [System.Serializable]
    public class Relation
    {
        [Header("Others Information")]
        public LogicGate _gate;
        public int _inputIndex;

        public Relation(LogicGate relation, int index)
        {
            _gate = relation;
            _inputIndex = index;
        }
    }

}


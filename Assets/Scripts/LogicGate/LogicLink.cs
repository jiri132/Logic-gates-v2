using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extentions.List;

namespace Logic
{
    [System.Serializable]
    public class LogicLink
    {
        public LogicGate _self;
        public int _outputIndex;

        public List<Relation> relations; 

        public LogicLink(LogicGate _self,int _outputIndex)
        {
            //create the object
            this._self = _self;
            this._outputIndex = _outputIndex;

            //create the list of relations
            relations = new List<Relation>();
        }

        public void Trigger(bool powered)
        {
            foreach (Relation relation in relations)
            {
                int index = relation._inputIndex;
                LogicGate relation_gate = relation._gate;

                relation_gate.inputs[index] = powered == true ? 1 : 0;
            }
        }
    }

    [System.Serializable]
    public class Relation
    {
        public LogicGate _gate;
        public int _inputIndex;

        public Relation(LogicGate relation, int index)
        {
            _gate = relation;
            _inputIndex = index;
        }
    }

}


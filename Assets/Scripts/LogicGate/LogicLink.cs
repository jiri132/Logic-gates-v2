using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic.Nodes;

namespace Logic
{
    [System.Serializable]
    public class LogicLink
    {
        [Header("Link Modules Owner")]
        [HideInInspector]
        public Node self;
       
        [Header("Links to Others")]
        public List<Relation> relations = new List<Relation>();

        public LogicLink(Node self)
        {
            //create the object
            this.self = self;
        }

        //based on the powered notification switch on or off the input
        public void Trigger(bool powered)
        {
            foreach (Relation relation in relations)
            {
                byte data = powered == true ? (byte)1 : (byte)0;
                relation.inputNode.state = data;
            }
        }

        public void CreateRelation(InputNode other)
        {
            relations.Add(new Relation(other));

            //acts as an Observable when connecting
            if (self.state == 1)
            {
                other.state = 1;
            }
        }
    }

    [System.Serializable]
    public class Relation
    {
        [Header("Others Information")]
        public InputNode inputNode;

        public Relation(InputNode relation)
        {
            inputNode = relation;
        }
    }

}


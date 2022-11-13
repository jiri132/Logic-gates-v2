using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    [System.Serializable]
    public class LogicBridge
    {
        public LogicComponent _self;
        public LogicLink[] links = new LogicLink[0];
    }
}
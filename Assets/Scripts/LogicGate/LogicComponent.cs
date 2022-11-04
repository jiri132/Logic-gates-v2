using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public abstract class LogicComponent : MonoBehaviour
    {
        public abstract TYPES GetLogicType();
        public abstract int[] GetInputsData();
        public abstract int[] GetOutputsData();

        public abstract void Start();
    }
}
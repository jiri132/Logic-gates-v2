using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public abstract class LogicComponent : MonoBehaviour
    {
        public abstract TYPES GetLogicType();
        public abstract int[] GetInputData();
        public abstract int[] GetOutputData();
        public abstract void SetInputData(int[] data);
        public abstract void SetInputData(int data,int index);

        public abstract void Start();
    }
}
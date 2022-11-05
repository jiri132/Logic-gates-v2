using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extentions.Observables
{
    //TODO: Make the observable be able to subscrie
    //TODO: Make the observables generic
    public class Observable
    {
        public event EventHandler SomethingHappened;

        
        public void DoSomething() => SomethingHappened?.Invoke(this, EventArgs.Empty);
    }
}


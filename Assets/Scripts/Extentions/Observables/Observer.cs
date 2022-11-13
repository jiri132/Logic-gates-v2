using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Extentions.Observables
{
    public class Observer
    {
        public void HandleEvent(object sender, EventArgs args)
        {
            Debug.Log("Something happened to " + sender);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;

public class NOTGate : LogicComponent
{
    #region Variables

    [Header("Linking Bridge")]
    [SerializeField]
    private LogicLink link;

    #endregion



    #region Overrides Of Component
    public override void Start()
    {
        link._self = this;
    }

    #endregion
}

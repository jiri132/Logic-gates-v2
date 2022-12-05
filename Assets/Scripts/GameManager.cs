using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logic;
using Extentions.Singleton;

public class GameManager : Singleton<GameManager>
{
    public Wire selectedWire;

    public List<LogicComponent> AllGates = new List<LogicComponent>();

    private void Start()
    {
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicSettings : MonoBehaviour
{
    public static LogicSettings Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public Color onColor;
    public Color offColor;
    
}

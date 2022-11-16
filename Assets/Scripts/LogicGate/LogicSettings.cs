using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Extentions.Singleton;

public class LogicSettings : Singleton<LogicSettings>
{
    public GameObject wirePrefab;

    public Color onColor;
    public Color offColor;

    public float interval = 0.01f;

}

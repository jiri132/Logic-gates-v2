using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Extentions.Singleton;

public class LogicSettings : Singleton<LogicSettings>
{
    [Header("Wire")]
    public GameObject wirePrefab;

    [Header("Coloring powered")]
    public Color onColor;
    public Color offColor;

    [Header("Simulation Clocking")]
    public float interval = 0.01f;

    [Header("Savefile prefix")]
    public string prefix = ".gate";
/*
    [Header("Path")]
    public string path = ;*/
}

using Extentions.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Logic;


public class Enviorment : Singleton<Enviorment>
{
    public InputField gateNameInput;
    public Color randomColor;
    public LogicComponent customGate;
    public bool _DEBUG = false;

    private void Start()
    {
        customGate = gameObject.GetComponent<LogicComponent>();
        randomColor = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    public void CreateNewGate()
    {
        SaveSystem1.SaveGate(new GateData(_DEBUG), gateNameInput.text);
    }
}

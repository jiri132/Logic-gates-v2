using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviorment : MonoBehaviour
{
    public string name = "";
    public Color randomColor;
    private void Start()
    {
        randomColor = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        SaveSystem1.SaveGate(new GateData(this), name);
    }


    public void CreateNewGate()
    {
        SaveSystem1.SaveGate(new GateData(this), name);
    }

}

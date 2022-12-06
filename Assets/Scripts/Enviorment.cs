using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enviorment : MonoBehaviour
{
    public InputField gateNameInput;
    public Color randomColor;
    private void Start()
    {
        randomColor = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
       
    }

    public void CreateNewGate()
    {
        SaveSystem1.SaveGate(new GateData(this), gateNameInput.text);
    }

}

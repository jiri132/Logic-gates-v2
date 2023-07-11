using Extentions.Singleton;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Logic;



public class Enviorment : Singleton<Enviorment>
{
    public InputField gateNameInput;
    public Color randomColor;
    public LogicComponent customGate;

    [Header("Debug tool for all ocassions")]
    public bool _DEBUG = false;

    [Header("Dictionary of gates")]
    public Dictionary<string, GateData> DictionaryOfGateData = new Dictionary<string, GateData>();

    private void Start()
    {
        StartCoroutine(RetrieveDictionaryOfGates());

        //Get the logicComponent for the minimal enviornment
        customGate = gameObject.GetComponent<LogicComponent>();

        //TODO: make the custom gate more customizable with custom colors instead of random
        // Give random color for created custom gate
        randomColor = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    private IEnumerator RetrieveDictionaryOfGates()
    {
        var dirInfo = new DirectoryInfo(Application.persistentDataPath);
        var fileInfo = dirInfo.GetFiles();
        foreach (var file in fileInfo)
        {
            string gateName = file.Name.Replace(LogicSettings.Instance.prefix,"");
            GateData data = SaveSystem1.LoadGate(gateName);
            yield return new WaitForSecondsRealtime(0.2f);

            DictionaryOfGateData.Add(gateName, data);
        }

        Debug.Log("Gates done loading");
    }

    public void CreateNewGate()
    {
        // Create the data of the custom gate
        GateData data = new GateData(_DEBUG);

        // Remove it from dictionary and Readd it later
        if (DictionaryOfGateData.ContainsKey(data.Name))
        {
            DictionaryOfGateData.Remove(data.Name);
        }

        // Add it directly to the dictionary
        DictionaryOfGateData.Add(data.Name,data);
        
        // Save the data to an .gate file
        SaveSystem1.SaveGate(data, gateNameInput.text);
    }
}

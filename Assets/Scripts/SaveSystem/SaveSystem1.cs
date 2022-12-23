using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class SaveSystem1
{
   public static void SaveGate(GateData data, string FileName)
   {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/{FileName}{LogicSettings.Instance.prefix}";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
       
        Debug.Log(path);

        stream.Close();
    }

    public static GateData LoadGate(string FileName)
    {
        string path = Application.persistentDataPath + $"/{FileName}{LogicSettings.Instance.prefix}";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GateData data = formatter.Deserialize(stream) as GateData;
            stream.Close();

            return data;
        }

        Debug.LogError("No gate fil found at" + path);
        return null;
        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class JsonSaveSystem
{
    private static string SaveFolder => Application.persistentDataPath;
    private static string SaveFile => Path.Combine(SaveFolder, "SaveDataJson.save");

    public void LoadPersistentData(ref PersistentData persistentData)
    {
        if (!File.Exists(SaveFile))
        {
            persistentData = new PersistentData();
        }
        else
        {
            string json = File.ReadAllText(SaveFile);
            JsonUtility.FromJsonOverwrite(json, persistentData);
        }
    }

    public void SavePersistentData(in PersistentData persistentData)
    {
        if (!Directory.Exists(SaveFolder))
            Directory.CreateDirectory(SaveFolder);

        string json = JsonUtility.ToJson(persistentData);
        File.WriteAllText(SaveFile, json);
    }
}

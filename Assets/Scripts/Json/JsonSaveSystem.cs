using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class JsonSaveSystem : MonoBehaviour
{
    [SerializeField] private SaveData _saveData = new SaveData();
    string path;

    void Awake()
    {
        string customDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).Replace("\\", "/") + "/" + Application.companyName + "/" + Application.productName;

        if (!Directory.Exists(customDirectory)) Directory.CreateDirectory(customDirectory);

        path = customDirectory + "/SaveDataJson.save";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) SaveGame();
        else if (Input.GetKeyDown(KeyCode.L)) LoadGame();
    }

    private void SaveGame()
    {
        string json = JsonUtility.ToJson(_saveData);
        File.WriteAllText(path, json);

        Debug.Log(json);
    }

    private void LoadGame()
    {
        string json = File.ReadAllText(path);

        JsonUtility.FromJsonOverwrite(json, _saveData);
    }
}

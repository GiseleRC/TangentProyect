using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class JsonSaveSystem : MonoBehaviour
{
    public static JsonSaveSystem Instance { get; private set; }

    [SerializeField] private SaveData _saveData = new SaveData();
    private string _path;

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        CreateDirectory();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) SaveGame();//cambiar
        else if (Input.GetKeyDown(KeyCode.L)) LoadGame();
    }

    private void CreateDirectory()
    {
        string customDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).Replace("\\", "/") + "/" + Application.companyName + "/" + Application.productName;

        if (!Directory.Exists(customDirectory)) Directory.CreateDirectory(customDirectory);

        _path = customDirectory + "/SaveDataJson.save";
    }
    private void SaveGame()
    {
        string json = JsonUtility.ToJson(_saveData);
        File.WriteAllText(_path, json);
    }

    private void LoadGame()
    {
        string json = File.ReadAllText(_path);
        JsonUtility.FromJsonOverwrite(json, _saveData);
    }
}

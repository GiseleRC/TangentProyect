using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class JsonSaveSystem : MonoBehaviour
{
    public static JsonSaveSystem Instance;

    [SerializeField] private SaveData _saveData = new SaveData();
    private string _path;
    private Scene _scene;

    public bool _level1Winn = true;
    public int _sceneIndex;

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        CreateDirectory();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) SaveGame();//cambiar
        else if (Input.GetKeyDown(KeyCode.L)) LoadGame();

        UpgradeScene();
        UpgradeLevelWinn();
    }

    private void UpgradeLevelWinn()
    {
        _saveData.level1Winn = _level1Winn;
    }

    private void UpgradeScene()
    {
        _scene = SceneManager.GetActiveScene();
        _sceneIndex = _scene.buildIndex;
        _saveData.sceneIndex = _sceneIndex;
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

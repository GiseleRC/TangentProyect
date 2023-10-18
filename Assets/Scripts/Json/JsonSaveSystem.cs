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

    public bool _level1Win;
    public bool _level2Win;
    public int _sceneIndex;
    public int _currency;

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        CreateDirectory();

        LoadGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) SaveGame();//cambiar
        else if (Input.GetKeyDown(KeyCode.L)) LoadGame();

        if (_level1Win)
        {
            UpgradeLevel1Winn();
            SaveGame();
        }

        if (_level2Win)
        {
            UpgradeLevel2Win();
            SaveGame();
        }

        UpgradeScene();
    }

    private void UpgradeLevel1Winn()
    {
        _saveData.level1Winn = _level1Win;
    }

    private void UpgradeLevel2Win()
    {
        _saveData.level2Winn = _level2Win;
    }

    private void UpgradeCuurency()
    {
        _currency++;
        _saveData.currency = _currency;
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

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(_saveData);
        File.WriteAllText(_path, json);
    }

    public void LoadGame()
    {
        string json = File.ReadAllText(_path);
        JsonUtility.FromJsonOverwrite(json, _saveData);

        _level1Win =_saveData.level1Win;
        _level2Win = _saveData.level2Win;
        _currency = _saveData.currency;
    }

    public void DeleteGame()
    {
        _saveData.level1Win = false;
        _saveData.level2Win = false;
        _saveData.currency = 0;
        SaveGame();
        LoadGame();
    }
}

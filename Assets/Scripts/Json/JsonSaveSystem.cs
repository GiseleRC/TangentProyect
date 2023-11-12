using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class JsonSaveSystem : Singleton<JsonSaveSystem>
{
    private static string _customDirectory;
    private static string _path;

    [SerializeField] private SaveData _saveData = new SaveData();
    //[SerializeField] private UIScreenController _tutorialMenuScript;

    private Scene _scene;

    public bool _level1Win;
    public bool _level2Win;
    public bool _tutorialMenu;
    public int _sceneIndex;
    public int _currency;

    void Awake()
    {
        CreateDirectory();
        LoadGame();
    }

    void Update()
    {
        //ver de poner boton
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

        if (_tutorialMenu)
        {
            UpgradeTutorialMenu();
            SaveGame();
        }

        UpgradeScene();

    }

    private void UpgradeLevel1Winn()
    {
        _saveData.level1Win = _level1Win;
    }

    private void UpgradeLevel2Win()
    {
        _saveData.level2Win = _level2Win;
    }

    //private void UpgradeCuurency()
    //{
    //    _currency++;
    //    _saveData.currency = _currency;
    //}

    private void UpgradeTutorialMenu()
    {
        _saveData.tutorialMenu = _tutorialMenu;
    }

    private void UpgradeScene()
    {
        _scene = SceneManager.GetActiveScene();
        _sceneIndex = _scene.buildIndex;
        _saveData.sceneIndex = _sceneIndex;
        LoadGame();
        SaveGame();
    }

    private void CreateDirectory()
    {
        _customDirectory = Application.persistentDataPath;
        _path = _customDirectory + "/SaveDataJson.save";

        if (!Directory.Exists(_customDirectory))
            Directory.CreateDirectory(_customDirectory);
    }

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(_saveData);
        File.WriteAllText(_path, json);
    }

    public void LoadGame()
    {
        _level1Win = _saveData.level1Win;
        _level2Win = _saveData.level2Win;
        _currency = _saveData.currency;
        _sceneIndex = _saveData.sceneIndex;
        _tutorialMenu = _saveData.tutorialMenu;

        string json = File.ReadAllText(_path);
        JsonUtility.FromJsonOverwrite(json, _saveData);
        SaveGame();
    }

    public void DeleteGame()
    {
        _saveData.level1Win = false;
        _saveData.level2Win = false;
        _saveData.tutorialMenu = false;
        _saveData.currency = 0;

        SaveGame();
        LoadGame();
    }
}

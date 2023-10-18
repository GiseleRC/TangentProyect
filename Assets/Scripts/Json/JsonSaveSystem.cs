using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class JsonSaveSystem : MonoBehaviour
{
    public static JsonSaveSystem Instance { get; private set; }

    [SerializeField] private SaveData _saveData = new SaveData();
    private string _path;
    private int _sceneIndex;
    private bool _level1Win;
    private Scene _scene;

    public int SceneIndex { get => _sceneIndex; set { } }
    public bool Level1Winn { get => _level1Win; set { } }

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

        UpgradeScene();
        UpgradeLevelWinn();
    }

    private void UpgradeLevelWinn()
    {
        _level1Win = _saveData.level1Winn;
    }

    private void UpgradeScene()
    {
        _scene = SceneManager.GetActiveScene();
        _saveData.sceneIndex = _scene.buildIndex;
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

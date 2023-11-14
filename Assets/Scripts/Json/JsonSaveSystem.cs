using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class JsonSaveSystem : Singleton<JsonSaveSystem>
{
    private static string _customDirectory;
    private static string _path;

    public SaveData SaveData { get; private set; } = new SaveData();

    void Awake()
    {
        _customDirectory = Application.persistentDataPath;
        _path = _customDirectory + "/SaveDataJson.save";

        EventManager.SubscribeToEvent(EventType.LevelEnded, OnLevelEnded);
        EventManager.SubscribeToEvent(EventType.TutorialCompleted, OnTutorialCompleted);

        LoadGame();
    }

    private void OnDestroy()
    {
        EventManager.UnsubscribeToEvent(EventType.LevelEnded, OnLevelEnded);
        EventManager.UnsubscribeToEvent(EventType.TutorialCompleted, OnTutorialCompleted);
    }

    private void OnLevelEnded(object[] parameters)
    {
        int level = (int)parameters[0];
        bool levelWon = (bool)parameters[1];

        if (!levelWon) return;

        SaveData.reachedLevel = Math.Max(SaveData.reachedLevel, level);
        SaveData.orbs += GameManager.Instance.RewardOrbs;

        SaveGame();
    }

    private void OnTutorialCompleted(object[] parameters)
    {
        SaveData.tutorialMenu = true;

        SaveGame();
    }

    public void LoadGame()
    {
        string json = File.ReadAllText(_path);
        JsonUtility.FromJsonOverwrite(json, SaveData);
    }

    public void SaveGame()
    {
        if (!Directory.Exists(_customDirectory))
            Directory.CreateDirectory(_customDirectory);

        string json = JsonUtility.ToJson(SaveData);
        File.WriteAllText(_path, json);
    }

    public void DeleteGame()
    {
        SaveData.Reset();

        SaveGame();
    }
}

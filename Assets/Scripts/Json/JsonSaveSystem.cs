using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class JsonSaveSystem : Singleton<JsonSaveSystem>
{
    private static string _customDirectory;
    private static string _path;

    public PersistentData PersistentData { get; private set; } = new PersistentData();

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

        PersistentData.reachedLevel = Math.Max(PersistentData.reachedLevel, level);
        PersistentData.orbs += GameManager.Instance.RewardOrbs;

        SaveGame();
    }

    private void OnTutorialCompleted(object[] parameters)
    {
        PersistentData.tutorialMenu = true;

        SaveGame();
    }

    public void LoadGame()
    {
        string json = File.ReadAllText(_path);
        JsonUtility.FromJsonOverwrite(json, PersistentData);
    }

    public void SaveGame()
    {
        if (!Directory.Exists(_customDirectory))
            Directory.CreateDirectory(_customDirectory);

        string json = JsonUtility.ToJson(PersistentData);
        File.WriteAllText(_path, json);
    }

    public void DeleteGame()
    {
        PersistentData.Reset();

        SaveGame();
    }
}

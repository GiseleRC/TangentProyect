using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    //Constant Data
    [SerializeField] private ConstantDataStats constantsDataStats;
    public ConstantDataStats ConstantsDataStats { get => constantsDataStats; }

    // Persistent Data
    private PersistentData persistentData = new PersistentData();
    public PersistentData PersistentData { get => persistentData; }

    // Volatile (Level) Data
    private VolatileData volatileData = new VolatileData();
    public VolatileData VolatileData { get => volatileData; }

    // Json
    private JsonSaveSystem jsonSaveSystem = new JsonSaveSystem();

    public override void Awake()
    {
        base.Awake();

        LoadPersistentData();

        EventManager.SubscribeToEvent(EventType.LevelStarted, OnLevelStarted);
        EventManager.SubscribeToEvent(EventType.LevelEnded, OnLevelEnded);
        EventManager.SubscribeToEvent(EventType.TutorialCompleted, OnTutorialCompleted);
    }

    private void OnDestroy()
    {
        EventManager.UnsubscribeToEvent(EventType.LevelStarted, OnLevelStarted);
        EventManager.UnsubscribeToEvent(EventType.LevelEnded, OnLevelEnded);
        EventManager.UnsubscribeToEvent(EventType.TutorialCompleted, OnTutorialCompleted);
    }

    private void OnLevelStarted(object[] parameters)
    {
        volatileData.CurrentLevel = (int)parameters[0];

        int mana = Math.Min(persistentData.Mana - ConstantsDataStats.ManaCostPerLevel, ConstantsDataStats.MaxManaCapacity);
        if (mana >= 0)
        {
            persistentData.Mana = mana;
        }

        ResetVolatileData();
        SavePersistentData();
    }

    private void OnLevelEnded(object[] parameters)
    {
        int level = (int)parameters[0];
        bool levelWon = (bool)parameters[1];

        if (!levelWon) return;

        persistentData.ReachedLevel = Math.Max(persistentData.ReachedLevel, level);
        int orbs = Math.Min(persistentData.Orbs + ConstantsDataStats.OrbsRewardPerLevel, ConstantsDataStats.OrbsRewardPerLevel);
        persistentData.Orbs = orbs;

        SavePersistentData();
    }

    private void OnTutorialCompleted(object[] parameters)
    {
        persistentData.tutorialCompleted = true;
        persistentData.Mana = 300;

        SavePersistentData();
    }

    public void LoadPersistentData()
    {
        jsonSaveSystem.LoadPersistentData(ref persistentData);
    }

    public void SavePersistentData()
    {
        jsonSaveSystem.SavePersistentData(persistentData);
    }

    public void ResetPersistentData()
    {
        persistentData.Reset();
        jsonSaveSystem.SavePersistentData(persistentData);
    }

    private void ResetVolatileData()
    {
        volatileData.Coins = ConstantsDataStats.InitialCoins;
        volatileData.Kills = ConstantsDataStats.InitialKills;
        volatileData.Lives = ConstantsDataStats.InitialLives;
    }
}

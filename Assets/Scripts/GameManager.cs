using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    [SerializeField] private int InitialCoins;
    [SerializeField] private int InitialKills;
    [SerializeField] private int InitialLives;
    [SerializeField] private int OrbsPerLevel;

    private JsonSaveSystem jsonSaveSystem = new JsonSaveSystem();

    private PersistentData persistentData = new PersistentData();
    public PersistentData PersistentData { get => persistentData; }

    public int CurrentLevel { get; private set; } = 0;

    private int coins;
    private int kills;
    private int lives;

    public int Coins { get => coins; set { coins = value; OnCoinsChanged?.Invoke(coins); } }
    public int Kills { get => kills; set { kills = value; OnKillsChanged?.Invoke(kills); } }
    public int Lives { get => lives; set { lives = value; OnLivesChanged?.Invoke(lives); } }

    public delegate void CoinsChangedHandler(int coins);
    public event CoinsChangedHandler OnCoinsChanged;

    public delegate void KillsChangedHandler(int kills);
    public event KillsChangedHandler OnKillsChanged;

    public delegate void LivesChangedHandler(int life);
    public event LivesChangedHandler OnLivesChanged;

    public override void Awake()
    {
        base.Awake();

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
        CurrentLevel = (int)parameters[0];
        ResetVolatileData();
    }

    private void OnLevelEnded(object[] parameters)
    {
        int level = (int)parameters[0];
        bool levelWon = (bool)parameters[1];

        if (!levelWon) return;

        persistentData.reachedLevel = Math.Max(persistentData.reachedLevel, level);
        persistentData.orbs += OrbsPerLevel;

        SavePersistentData();
    }

    private void OnTutorialCompleted(object[] parameters)
    {
        persistentData.tutorialMenu = true;

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
        Coins = InitialCoins;
        Kills = InitialKills;
        Lives = InitialLives;
    }
}

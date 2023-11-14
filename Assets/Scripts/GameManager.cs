using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int InitialCoins;
    [SerializeField] private int InitialKills;
    [SerializeField] private int InitialLives;
    public Transform _spawnPoint;

    public delegate void CoinsChangedHandler(int coins);
    public event CoinsChangedHandler OnCoinsChanged;

    public delegate void KillsChangedHandler(int kills);
    public event KillsChangedHandler OnKillsChanged;

    public delegate void LivesChangedHandler(int life);
    public event LivesChangedHandler OnLivesChanged;

    private int coins;
    private int kills;
    private int lives;

    public int Coins { get => coins; set { coins = value; OnCoinsChanged?.Invoke(coins); } }
    public int Kills { get => kills; set { kills = value; OnKillsChanged?.Invoke(kills); } }
    public int Lives { get => lives; set { lives = value; OnLivesChanged?.Invoke(lives); } }

    public int RewardOrbs { get; private set; } = 100;
    public int CurrentLevel { get; private set; } = 0;

    private void Awake()
    {
        Coins = InitialCoins;
        Kills = InitialKills;
        Lives = InitialLives;

        EventManager.SubscribeToEvent(EventType.LevelStarted, OnLevelStarted);
    }

    private void OnDestroy()
    {
        EventManager.UnsubscribeToEvent(EventType.LevelStarted, OnLevelStarted);
    }

    private void OnLevelStarted(object[] parameters)
    {
        CurrentLevel = (int)parameters[0];
    }
}

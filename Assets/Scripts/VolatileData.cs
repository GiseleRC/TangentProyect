using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class VolatileData
{
    public int _initialCoins;
    public int _initialKills;
    public int _initialLives;

    private int _coins;
    private int _kills;
    private int _lives;
    private int _currentLevel;

    public int Coins { get => _coins; set { _coins = value; OnCoinsChanged?.Invoke(_coins); } }
    public int Kills { get => _kills; set { _kills = value; OnKillsChanged?.Invoke(_kills); } }
    public int Lives { get => _lives; set { _lives = value; OnLivesChanged?.Invoke(_lives); } }
    public int CurrentLevel { get => _currentLevel; set { _currentLevel = value; OnLevelChanged?.Invoke(_currentLevel); } }

    public delegate void CoinsChangedHandler(int coins);
    public event CoinsChangedHandler OnCoinsChanged;

    public delegate void KillsChangedHandler(int kills);
    public event KillsChangedHandler OnKillsChanged;

    public delegate void LivesChangedHandler(int life);
    public event LivesChangedHandler OnLivesChanged;

    public delegate void LevelChangedHandler(int level);
    public event LevelChangedHandler OnLevelChanged;
}

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class VolatileData
{
    private int coins;
    private int kills;
    private int lives;
    private int currentLevel;

    public int Coins { get => coins; set { coins = value; OnCoinsChanged?.Invoke(coins); } }
    public int Kills { get => kills; set { kills = value; OnKillsChanged?.Invoke(kills); } }
    public int Lives { get => lives; set { lives = value; OnLivesChanged?.Invoke(lives); } }
    public int CurrentLevel { get => currentLevel; set { currentLevel = value; OnLevelChanged?.Invoke(currentLevel); } }

    public delegate void CoinsChangedHandler(int coins);
    public event CoinsChangedHandler OnCoinsChanged;

    public delegate void KillsChangedHandler(int kills);
    public event KillsChangedHandler OnKillsChanged;

    public delegate void LivesChangedHandler(int life);
    public event LivesChangedHandler OnLivesChanged;

    public delegate void LevelChangedHandler(int level);
    public event LevelChangedHandler OnLevelChanged;
}

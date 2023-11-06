using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int InitialCoins;
    [SerializeField] private int InitialKills;
    [SerializeField] private int InitialLifes;
    public Transform _spawnPoint;

    public delegate void CoinsChangedHandler(int coins);
    public event CoinsChangedHandler OnCoinsChanged;

    public delegate void KillsChangedHandler(int kills);
    public event KillsChangedHandler OnKillsChanged;

    public delegate void LifesChangedHandler(int life);
    public event LifesChangedHandler OnLifesChanged;

    private int coins;
    private int kills;
    private int lifes;

    public int Coins { get => coins; set { coins = value; OnCoinsChanged?.Invoke(coins); } }
    public int Kills { get => kills; set { kills = value; OnKillsChanged?.Invoke(kills); } }
    public int Lifes { get => lifes; set { lifes = value; OnLifesChanged?.Invoke(lifes); } }

    private void Start()
    {
        Coins = InitialCoins;
        Kills = InitialKills;
        Lifes = InitialLifes;
    }
}

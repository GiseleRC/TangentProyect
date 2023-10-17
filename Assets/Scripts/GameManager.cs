using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int InitialCoins;
    [SerializeField] private int InitialKills;
    public Transform _spawnPoint;

    public static GameManager Instance { get; private set; }

    public delegate void CoinsChangedHandler(int coins);
    public event CoinsChangedHandler OnCoinsChanged;

    public delegate void KillsChangedHandler(int kills);
    public event KillsChangedHandler OnKillsChanged;

    private int coins;
    private int kills;

    public int Coins { get => coins; set { coins = value; OnCoinsChanged?.Invoke(coins); } }
    public int Kills { get => kills; set { kills = value; OnKillsChanged?.Invoke(kills); } }

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;

    }

    private void Start()
    {
        Coins = InitialCoins;
        Kills = InitialKills;
    }
}

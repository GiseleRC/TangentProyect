using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int InitialCoins;

    public static GameManager Instance { get; private set; }

    public delegate void CoinsChangedHandler(int coins);
    public event CoinsChangedHandler OnCoinsChanged;

    private int coins;
    public int Coins { get => coins; set { coins = value; OnCoinsChanged?.Invoke(coins); } }

    public int Kills { get; private set; }

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
    }
}

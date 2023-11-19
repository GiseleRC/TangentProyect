using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantData : MonoBehaviour
{
    [SerializeField] private ConstantDataStats _constantDataStats;

    private int _initialCoins;
    private int _initialKills;
    private int _initialLives;
    private int _orbsRewardPerLevel;
    private int _manaCostPerLevel;
    private int _maxManaCapacity;//3
    private float _timerToRecharge;//10f

    void Start()
    {
        ResetData();
    }

    public void ResetData()
    {
        _initialCoins = _constantDataStats.InitialCoins;
        _initialKills = _constantDataStats.InitialKills;
        _initialLives = _constantDataStats.InitialLives;
        _orbsRewardPerLevel = _constantDataStats.OrbsRewardPerLevel;
        _manaCostPerLevel = _constantDataStats.ManaCostPerLevel;
        _maxManaCapacity = _constantDataStats.MaxManaCapacity;
    }
}

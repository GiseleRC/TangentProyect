using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Constants Data Stats", menuName = "ScriptableObjects/GameCore/ConstantsDataStats")]
public class ConstantDataStats : ScriptableObject
{
    [SerializeField] private int _initialCoins;
    [SerializeField] private int _initialKills;
    [SerializeField] private int _initialLives;
    [SerializeField] private int _orbsRewardPerLevel;
    [SerializeField] private int _manaCostPerLevel;
    [SerializeField] private int _maxManaCapacity;

    public int InitialCoins { get => _initialCoins; }
    public int InitialKills { get => _initialKills; }
    public int InitialLives { get => _initialLives; }
    public int OrbsRewardPerLevel { get => _orbsRewardPerLevel; }
    public int ManaCostPerLevel { get => _manaCostPerLevel; }
    public int MaxManaCapacity { get => _maxManaCapacity; }
}

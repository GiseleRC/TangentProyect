using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp Stats", menuName = "ScriptableObjects/GameCore/PowerUp Stats")]
public class PowerUpStats : ScriptableObject
{
    [SerializeField] private int _multipDamage;
    [SerializeField] private float _powerUpDuration;
    [SerializeField] private int _powerUpCost;

    public int MultiplyDamage { get => _multipDamage; }
    public float PowerUpDuration { get => _powerUpDuration; }
    public int PowerUpCost { get => _powerUpCost; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Stats", menuName = "ScriptableObjects/GameCore/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private int _killPrice;

    public int Health { get => _health; }

    public float Speed { get => _speed; }

    public int KillPrice { get => _killPrice; }
}

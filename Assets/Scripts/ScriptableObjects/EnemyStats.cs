using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Stats", menuName = "ScriptableObjects/GameCore/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;

    public int Health { get => _health; }

    public float Speed { get => _speed; }
}

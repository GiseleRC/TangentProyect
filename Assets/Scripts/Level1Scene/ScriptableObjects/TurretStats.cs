using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Turret Stats", menuName = "ScriptableObjects/GameCore/TurretStats")]
public class TurretStats : ScriptableObject
{
    [SerializeField] private float _range;
    [SerializeField] private float _fireRate;

    public float Range { get => _range; }

    public float FireRate { get => _fireRate; }
}

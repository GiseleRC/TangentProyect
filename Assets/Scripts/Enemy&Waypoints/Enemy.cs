using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour, IPooleableObject
{
    private float _health;
    private Transform _target;
    private int _waypointsIndex = 0;

    [SerializeField] private TypeEnemy _typeEnemy;
    [SerializeField] private EnemyStats _stats;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private WaveSpawner waveSpawner;
    [SerializeField] private AudioSource _dieSound;

    [SerializeField] private int _enemyDamageToBase;

    public enum TypeEnemy
    {
        Basic,
        Heavy
    }

    void Start()
    {
        _target = Waypoints.points[0];
        _health = _stats.Health;
    }

    void Update()
    {
        Vector3 _dir = _target.position - transform.position;
        transform.Translate(_dir.normalized * _stats.Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if(_waypointsIndex >= Waypoints.points.Length -1)
        {
            Die();
            UIDeath.Instance.BaseDamage(_enemyDamageToBase);
            return;
        }
        _waypointsIndex++;
        _target = Waypoints.points[_waypointsIndex];
    }

    public void Reset()
    {
        _target = Waypoints.points[0];
        _waypointsIndex = 0;
        transform.position = waveSpawner._spawnPoint.position;
    }

    public static void TurnOn(Enemy enemy)
    {
        enemy.Reset();
        enemy.gameObject.SetActive(true);
    }

    public static void TurnOff(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    public void TakeDamage(int damageAmounth)
    {
        _dieSound.Play();
        _health -= damageAmounth;
        if (_health <= 0)
        {
            GameManager.Instance.VolatileData.Coins += _stats.KillPrice;
            GameManager.Instance.VolatileData.Kills++;
            _health = _stats.Health;
            Die();
        }
    }

    private void Die()
    {
        if (_typeEnemy == TypeEnemy.Basic)
        {
            EnemyBasicFactory.Instance.ReturnObjectToPool(this);
        }
        else if (_typeEnemy == TypeEnemy.Heavy)
        {
            EnemyHeavyFactory.Instance.ReturnObjectToPool(this);
        }
    }
}
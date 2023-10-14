using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicFactory : EnemyFactory
{
    public static EnemyBasicFactory Instance { get; private set; }

    [SerializeField] private Enemy _basicEnemyPrefab;
    //[SerializeField] private int   _initialAmount;

    private Pool<Enemy> _myBasicEnemyPool;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        _myBasicEnemyPool = new Pool<Enemy>(CreateObject, Enemy.TurnOn, Enemy.TurnOff, _initialAmount);
    }

    protected override Enemy CreateObject()
    {
        return Instantiate(_basicEnemyPrefab);
    }

    public override Enemy GetObjectFromPool()
    {
        return _myBasicEnemyPool.GetObject();
    }

    public override void ReturnObjectToPool(Enemy enemy)
    {
        _myBasicEnemyPool.ReturnObject(enemy);
    }
}
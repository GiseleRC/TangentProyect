using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicFactory : EnemyFactory<EnemyBasicFactory>
{
    [SerializeField] private Enemy _basicEnemyPrefab;

    private Pool<Enemy> _myBasicEnemyPool;

    void Awake()
    {
        _myBasicEnemyPool = new Pool<Enemy>(CreateObject, Enemy.TurnOn, Enemy.TurnOff, _initialAmount);
    }

    protected override Enemy CreateObject()
    {
        return Instantiate(_basicEnemyPrefab, _root);
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeavyFactory : EnemyFactory<EnemyHeavyFactory>
{
    [SerializeField] private Enemy _heavyEnemyPrefab;

    private Pool<Enemy> _myHeavyEnemyPool;

    void Awake()
    {
        _myHeavyEnemyPool = new Pool<Enemy>(CreateObject, Enemy.TurnOn, Enemy.TurnOff, _initialAmount);
    }

    protected override Enemy CreateObject()
    {
        return Instantiate(_heavyEnemyPrefab, _root);
    }

    public override Enemy GetObjectFromPool()
    {
        return _myHeavyEnemyPool.GetObject();
    }

    public override void ReturnObjectToPool(Enemy enemy)
    {
        _myHeavyEnemyPool.ReturnObject(enemy);
    }
}
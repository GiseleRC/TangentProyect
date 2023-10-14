using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeavyFactory : EnemyFactory
{
    public static new EnemyHeavyFactory Instance { get; private set; }

    [SerializeField] private Enemy _heavyEnemyPrefab;
    [SerializeField] private int _killPrice;

    private Pool<Enemy> _myHeavyEnemyPool;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        _myHeavyEnemyPool = new Pool<Enemy>(CreateObject, Enemy.TurnOn, Enemy.TurnOff, _initialAmount);
    }

    protected override Enemy CreateObject()
    {
        return Instantiate(_heavyEnemyPrefab);
    }

    public override Enemy GetObjectFromPool()
    {

        return _myHeavyEnemyPool.GetObject();
    }

    public override void ReturnObjectToPool(Enemy enemy)
    {
        _myHeavyEnemyPool.ReturnObject(enemy);
        GameManager.Instance.Coins += _killPrice;
        GameManager.Instance.Kills ++;
    }
}
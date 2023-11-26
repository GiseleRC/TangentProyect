using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFactory : Singleton<EnemyFactory>
{
    [SerializeField] protected Transform _root = null;
    [SerializeField] protected int _initialAmount;

    abstract protected Enemy CreateObject();

    abstract public Enemy GetObjectFromPool();

    abstract public void ReturnObjectToPool(Enemy enemy);
}

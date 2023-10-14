using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFactory : MonoBehaviour
{
    public static EnemyFactory Instance { get; private set; }

    [SerializeField] protected int _initialAmount;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    abstract protected Enemy CreateObject();

    abstract public Enemy GetObjectFromPool();

    abstract public void ReturnObjectToPool(Enemy enemy);
}

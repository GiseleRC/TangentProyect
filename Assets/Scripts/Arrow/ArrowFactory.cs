using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFactory : Singleton<ArrowFactory>
{
    [SerializeField] private Arrow _arrowPrefab;
    [SerializeField] protected Transform _root = null;
    [SerializeField] private int _initialAmount;

    private Pool<Arrow> _myArrowPool;

    void Awake()
    {
        _myArrowPool = new Pool<Arrow>(CreateObject, Arrow.TurnOn, Arrow.TurnOff, _initialAmount);
    }

    Arrow CreateObject()
    {
        return Instantiate(_arrowPrefab, _root);
    }

    public Arrow GetObjectFromPool()
    {
        return _myArrowPool.GetObject();
    }

    public void ReturnObjectToPool(Arrow arrow)
    {
        _myArrowPool.ReturnObject(arrow);
    }
}

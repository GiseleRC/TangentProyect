using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFactory : MonoBehaviour
{
    public static ArrowFactory Instance { get; private set; }

    [SerializeField] private Arrow _arrowPrefab;
    [SerializeField] private int _initialAmount;

    private Pool<Arrow> _myArrowPool;

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        _myArrowPool = new Pool<Arrow>(CreateObject, Arrow.TurnOn, Arrow.TurnOff, _initialAmount);
    }

    Arrow CreateObject()
    {
        return Instantiate(_arrowPrefab);
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

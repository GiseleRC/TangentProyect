using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GachaSystem : MonoBehaviour
{
    [SerializeField] private GachaPool[] _myPool = new GachaPool[0];
    [SerializeField] private int _pitySystem = 10;

    [SerializeField] public TextMeshProUGUI resultGacha;

    private float _totalChance;
    private int _pullCount;

    void Start()
    {
        _totalChance = 0;

        for (int i = 0; i < _myPool.Length; i++)
        {
            _totalChance += _myPool[i].appearChance;


            for (int j = 0; j < _myPool[i].myItems.Length; j++)
            {
                _myPool[i].myItems[j].rarity = _myPool[i].rarity;
            }
        }
    }

    public void PullGacha(int pullNumber)
    {
        GameManager.Instance.PersistentData.Orbs -= pullNumber * 10;

        GameManager.Instance.SavePersistentData();

        for (int i = 0; i < pullNumber; i++)
        {
            var itemWithPity = GetItemWithPity();

            resultGacha.text = "You have received: " + itemWithPity.name + " of " + itemWithPity.rarity + " rarity ";
        }
    }

    private Item GetItemWithPity()
    {
        GachaPool tempPool = null;
        _pullCount++;

        if(_pullCount >= _pitySystem)
        {
            tempPool = _myPool[0];
        }
        else
        {
            float randomValue = Random.Range(0, _totalChance);

            for (int i = 0; i < _myPool.Length; i++)
            {
                randomValue -= _myPool[i].appearChance;
                if (randomValue <= 0)
                {
                    tempPool = _myPool[i];
                    break;
                }
            }
        }

        if(tempPool.rarity == ItemsRarity.UltraRare) _pullCount = 0;

        int randomItem = Random.Range(0, tempPool.myItems.Length);

        return tempPool.myItems[randomItem];
    }

}

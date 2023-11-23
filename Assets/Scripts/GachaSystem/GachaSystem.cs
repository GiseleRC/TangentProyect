using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GachaSystem : MonoBehaviour
{
    [SerializeField] private GachaPool[] _myPool = new GachaPool[0];
    [SerializeField] private int _pitySystem = 10;

    [SerializeField] public TextMeshProUGUI result;
    [SerializeField] public TextMeshProUGUI commonRunes;
    [SerializeField] public TextMeshProUGUI rareRunes;
    [SerializeField] public TextMeshProUGUI superrareRunes;
    [SerializeField] public TextMeshProUGUI ultrarareRunes;

    private float _totalChance;
    private int _pullCount;
    private int _commonRunes = 0;
    private int _rareRunes = 0;
    private int _superrareRunes = 0;
    private int _ultrarareRunes = 0;

    void Start()
    {
        UpdateUI();

        result.text = " ";

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
        }
        result.text = "You have received: " + _commonRunes + " RUNES of COMMON rarity " + "\n" + "You have received: " + _rareRunes + " RUNES of RARE rarity " + "\n" + "You have received: " + _superrareRunes + " RUNES of SUPERRARE rarity " + "\n" + "You have received: " + _ultrarareRunes + " RUNES of ULTRARARE rarity ";

        RunesTrade.Instance.HasRunesToTrade();
        UpdateRunes();
        UpdateUI();

        _commonRunes = 0;
        _rareRunes = 0;
        _superrareRunes = 0;
        _ultrarareRunes = 0;
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

        for (int i = 0; i < tempPool.myItems.Length; i++)
        {
            if(tempPool.myItems[i].rarity == ItemsRarity.Common)
            {
                _commonRunes++;
            }
            else if (tempPool.myItems[i].rarity == ItemsRarity.Rare)
            {
                _rareRunes++;
            }
            else if (tempPool.myItems[i].rarity == ItemsRarity.SuperRare)
            {
                _superrareRunes++;
            }
            else if (tempPool.myItems[i].rarity == ItemsRarity.UltraRare)
            {
                _ultrarareRunes++;
            }
        }

        return tempPool.myItems[randomItem];
    }

    private void UpdateRunes()
    {
        GameManager.Instance.PersistentData.commonRunesMount += _commonRunes;
        GameManager.Instance.PersistentData.rareRunesMount += _rareRunes;
        GameManager.Instance.PersistentData.superRareRunesMount += _superrareRunes;
        GameManager.Instance.PersistentData.ultraRareRunesMount += _ultrarareRunes;

        GameManager.Instance.SavePersistentData();
    }

    private void UpdateUI()
    {
        commonRunes.text = GameManager.Instance.PersistentData.commonRunesMount.ToString();
        rareRunes.text = GameManager.Instance.PersistentData.rareRunesMount.ToString();
        superrareRunes.text = GameManager.Instance.PersistentData.superRareRunesMount.ToString();
        ultrarareRunes.text = GameManager.Instance.PersistentData.ultraRareRunesMount.ToString();

        GameManager.Instance.SavePersistentData();
    }
}

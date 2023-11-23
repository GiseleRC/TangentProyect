using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RunesTrade : Singleton<RunesTrade>
{
    [SerializeField] public TextMeshProUGUI commonRunes;
    [SerializeField] public TextMeshProUGUI rareRunes;
    [SerializeField] public TextMeshProUGUI superrareRunes;
    [SerializeField] public TextMeshProUGUI ultrarareRunes;

    [SerializeField] public Image common;
    [SerializeField] public Image rare;
    [SerializeField] public Image superrare;
    [SerializeField] public Image ultrarare;

    [SerializeField] public Button commonBt;
    [SerializeField] public Button rareBt;
    [SerializeField] public Button superrareBt;
    [SerializeField] public Button ultrarareBt;

    private int maxPricetrade = 400;
    void Start()
    {
        HasRunesToTrade();
    }

    public void HasRunesToTrade()
    {
        if (GameManager.Instance.PersistentData.commonRunesMount >= maxPricetrade)
        {
            common.enabled = true;
            commonBt.interactable = true;
        }
        else
        {
            common.enabled = false;
            commonBt.interactable = false;
        }

        if (GameManager.Instance.PersistentData.rareRunesMount >= maxPricetrade)
        {
            rare.enabled = true;
            rareBt.interactable = true;
        }
        else
        {
            rare.enabled = false;
            rareBt.interactable = false;
        }

        if (GameManager.Instance.PersistentData.superRareRunesMount >= maxPricetrade)
        {
            superrare.enabled = true;
            superrareBt.interactable = true;
        }
        else
        {
            superrare.enabled = false;
            superrareBt.interactable = false;
        }

        if (GameManager.Instance.PersistentData.ultraRareRunesMount >= maxPricetrade)
        {
            ultrarare.enabled = true;
            ultrarareBt.interactable = true;
        }
        else
        {
            ultrarare.enabled = false;
            ultrarareBt.interactable = false;
        }
    }

    public void Trade(TextMeshProUGUI textMesh)
    {
        if (textMesh.text == commonRunes.text)
        {
            GameManager.Instance.PersistentData.commonRunesMount -= maxPricetrade;
            GameManager.Instance.PersistentData.tradeCoinsMount += 2;
            commonRunes.text = GameManager.Instance.PersistentData.commonRunesMount.ToString();
        }
        else if (textMesh.text == rareRunes.text)
        {
            GameManager.Instance.PersistentData.rareRunesMount -= maxPricetrade;
            GameManager.Instance.PersistentData.tradeCoinsMount += 5;
            rareRunes.text = GameManager.Instance.PersistentData.rareRunesMount.ToString();
        }
        else if (textMesh.text == superrareRunes.text)
        {
            GameManager.Instance.PersistentData.superRareRunesMount -= maxPricetrade;
            GameManager.Instance.PersistentData.tradeCoinsMount += 10;
            superrareRunes.text = GameManager.Instance.PersistentData.superRareRunesMount.ToString();
        }
        else if (textMesh.text == ultrarareRunes.text)
        {
            GameManager.Instance.PersistentData.ultraRareRunesMount -= maxPricetrade;
            GameManager.Instance.PersistentData.tradeCoinsMount += 50;
            ultrarareRunes.text = GameManager.Instance.PersistentData.ultraRareRunesMount.ToString();
        }

        HasRunesToTrade();
        GameManager.Instance.SavePersistentData();
    }

}

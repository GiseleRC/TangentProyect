using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICoins : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        GameManager.Instance.VolatileData.OnCoinsChanged += OnCoinsChanged;
        _text.text = GameManager.Instance.VolatileData.Coins.ToString();
    }

    private void OnDestroy()
    {
        GameManager.Instance.VolatileData.OnCoinsChanged -= OnCoinsChanged;
    }

    private void OnCoinsChanged(int coins)
    {
        _text.text = coins.ToString();
    }
}

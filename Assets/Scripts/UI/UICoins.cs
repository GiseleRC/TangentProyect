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

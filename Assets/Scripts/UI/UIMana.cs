using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMana : MonoBehaviour
{
    [SerializeField] private Slider _manaValue;

    [SerializeField] private Button _manaRecharge;

    private void Start()
    {
        UpdateUI(GameManager.Instance.PersistentData.Mana);

        GameManager.Instance.PersistentData.OnManaChanged += OnManaChanged;

        _manaRecharge.onClick.AddListener(RechargeMana);
    }

    private void OnDestroy()
    {
        GameManager.Instance.PersistentData.OnManaChanged -= OnManaChanged;
    }

    private void OnManaChanged(int mana)
    {
        UpdateUI(mana);
    }

    private void UpdateUI(int mana)
    {
        _manaValue.value = mana;
    }

    private void RechargeMana()
    {
        GameManager.Instance.PersistentData.Mana = 300;
        UpdateUI(GameManager.Instance.PersistentData.Mana);
    }
}

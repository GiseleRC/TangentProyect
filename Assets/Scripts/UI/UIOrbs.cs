using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOrbs : MonoBehaviour
{
    [SerializeField] private Slider _orbsValue;

    [SerializeField] private Button _orbsRecharge;

    private void Start()
    {
        UpdateUI(GameManager.Instance.PersistentData.Orbs);

        GameManager.Instance.PersistentData.OnOrbsChanged += OnOrbsChanged;

        _orbsRecharge.onClick.AddListener(RechargeOrbs);
    }

    private void OnDestroy()
    {
        GameManager.Instance.PersistentData.OnOrbsChanged -= OnOrbsChanged;
    }

    private void OnOrbsChanged(int orbs)
    {
        UpdateUI(orbs);
    }

    public void UpdateUI(int orbs)
    {
        _orbsValue.value = orbs;
    }

    private void RechargeOrbs()
    {
        GameManager.Instance.PersistentData.Orbs = 500;
        UpdateUI(GameManager.Instance.PersistentData.Orbs);
    }
}

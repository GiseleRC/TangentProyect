using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOrbs : MonoBehaviour
{
    [SerializeField] private Slider _orbsValue;

    private void Start()
    {
        UpdateUI(GameManager.Instance.PersistentData.Orbs);

        GameManager.Instance.PersistentData.OnOrbsChanged += OnOrbsChanged;
    }

    private void OnDestroy()
    {
        GameManager.Instance.PersistentData.OnOrbsChanged -= OnOrbsChanged;
    }

    private void OnOrbsChanged(int orbs)
    {
        UpdateUI(orbs);
    }

    private void UpdateUI(int orbs)
    {
        _orbsValue.value = orbs;
    }
}

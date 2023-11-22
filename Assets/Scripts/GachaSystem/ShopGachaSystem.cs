using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopGachaSystem : MonoBehaviour
{
    [SerializeField] private ItemButton _buttonPrefab;
    [SerializeField] private Transform _buttonParent;

    [SerializeField] private Button _pull1;
    [SerializeField] private Button _pull10;

    [SerializeField] private GameObject _luckyPushScrollView;

    [SerializeField] private GachaSystem _gachaSystem;

    [SerializeField] private Item[] _items = new Item[0];

    void Start()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            var newItem = Instantiate(_buttonPrefab, _buttonParent.parent);
            newItem.SetItem(_items[i]);
        }

        GameManager.Instance.PersistentData.OnOrbsChanged += OnOrbsChanged;
    }
    private void OnDestroy()
    {
        GameManager.Instance.PersistentData.OnOrbsChanged -= OnOrbsChanged;
    }

    private void OnOrbsChanged(int orbs)
    {
        if (orbs >= 100)
        {
            _pull1.interactable = true;
            _pull10.interactable = true;
        }
        else if (orbs < 100 && orbs >= 10)
        {
            _pull1.interactable = true;
            _pull10.interactable = false;
        }
        else
        {
            EnablePullButtons(false);
            _gachaSystem.resultGacha.text = " ";
        }
    }

    public void OpenLuckyPush()
    {
        _luckyPushScrollView.SetActive(EnablePullButtons(GameManager.Instance.PersistentData.Orbs >= 10));
    }

    public bool EnablePullButtons(bool enable)
    {
        _pull1.interactable = enable;
        _pull10.interactable = enable;

        return enable;
    }

    public void CloseLuckyPush()
    {
        _luckyPushScrollView.SetActive(false);

        GameManager.Instance.SavePersistentData();
    }
}
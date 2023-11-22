using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIMana : Singleton<UIMana>
{
    [SerializeField] private Slider _manaValue;
    [SerializeField] private Button _manaRecharge;

    [SerializeField] private TextMeshProUGUI _currentManaValue= null;//ver como gamemanager notifica para que se ejeccute el cambio interno
    [SerializeField] private TextMeshProUGUI _manaTimerValue = null;

    private void Start()
    {
        UpdateUI(GameManager.Instance.PersistentData.Mana);

        GameManager.Instance.PersistentData.OnManaChanged += OnManaChanged;

        _manaRecharge.onClick.AddListener(RechargeMana);//Boton de para el profe
    }
    private void RechargeMana()//Boton para el profe
    {
        GameManager.Instance.PersistentData.Mana = 3;
        UpdateUI(GameManager.Instance.PersistentData.Mana);
    }

    private void OnDestroy()
    {
        GameManager.Instance.PersistentData.OnManaChanged -= OnManaChanged;
    }

    private void OnManaChanged(int mana)
    {
        UpdateUI(mana);
    }

    public void UpdateUI(int mana)
    {
        _manaValue.value = mana;
        _currentManaValue.text = mana.ToString() + "/3";

       if (GameManager.Instance.PersistentData.Mana >= GameManager.Instance.ConstantsDataStats.MaxManaCapacity)
       {
           _manaTimerValue.text = "Full stamina!";
           return;
       }

        TimeSpan timer = GameManager.Instance.PersistentData.NextManaTime - DateTime.Now;

        _manaTimerValue.text = timer.Minutes.ToString("00") + ":" + timer.Seconds.ToString("00");
    }
}

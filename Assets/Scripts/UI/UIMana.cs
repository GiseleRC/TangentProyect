using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMana : MonoBehaviour
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

        Debug.Log(GameManager.Instance.PersistentData.NextManaTime + " ----------- " + GameManager.Instance.PersistentData.LastManaTime);
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
}

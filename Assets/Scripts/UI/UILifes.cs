using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILifes : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        GameManager.Instance.OnLifesChanged += Instance_OnLifesChanged;
    }

    private void Instance_OnLifesChanged(int lifes)
    {
        _text.text = lifes.ToString();
    }
}
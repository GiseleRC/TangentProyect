using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILifes : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        GameManager.Instance.OnLivesChanged += Instance_OnLivesChanged;
    }

    private void Instance_OnLivesChanged(int lifes)
    {
        _text.text = lifes.ToString();
    }
}
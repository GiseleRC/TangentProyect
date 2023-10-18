using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonsLevel2 : MonoBehaviour
{
    [SerializeField] private GameObject _nodeEnableButton;
    [SerializeField] private GameObject _powerUpButton;
    [SerializeField] private JsonSaveSystem _jsonSaves;
    private bool _enableButtonsLevel2;

    private void Update()
    {
        _enableButtonsLevel2 = _jsonSaves._level1Winn;

        if (_enableButtonsLevel2 && _jsonSaves._sceneIndex == 2)
        {
            EnableButtons();
            _enableButtonsLevel2 = false;
        }
    }

    private void EnableButtons()
    {
        _nodeEnableButton.SetActive(true);
        _powerUpButton.SetActive(true);
    }
}

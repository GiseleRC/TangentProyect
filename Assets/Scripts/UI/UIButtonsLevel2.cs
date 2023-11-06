using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonsLevel2 : MonoBehaviour
{
    [SerializeField] private GameObject _nodeEnableButton;
    [SerializeField] private GameObject _powerUpButton;
    private bool _enableButtonsLevel2 = true;

    private void Update()
    {
        if (JsonSaveSystem.Instance._level1Win && JsonSaveSystem.Instance._sceneIndex == 2)
        {
            if (_enableButtonsLevel2)
            {
                EnableButtons();
                _enableButtonsLevel2 = false;
            }
        }
    }

    private void EnableButtons()
    {
        _nodeEnableButton.SetActive(true);
        _powerUpButton.SetActive(true);
    }
}

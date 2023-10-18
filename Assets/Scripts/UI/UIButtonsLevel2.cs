using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonsLevel2 : MonoBehaviour
{
    [SerializeField] private GameObject _nodeEnableButton;
    [SerializeField] private GameObject _powerUpButton;
    private bool _enableButtonsLevel2;

    private void Update()
    {
        _enableButtonsLevel2 = JsonSaveSystem.Instance.Level1Winn;

        if (_enableButtonsLevel2 && JsonSaveSystem.Instance.SceneIndex == 2)
        {
            EnableButtons();
        }
    }

    private void EnableButtons()
    {
        _nodeEnableButton.SetActive(true);
        _powerUpButton.SetActive(true);
    }
}

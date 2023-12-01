using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelButtonsBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;
    [SerializeField] private Button rewardButton;

    private int _currentIndex = 0;
    private float _activationDuration = 1f;
    private int _correctButtonCount = 0;
    private int _correctButtonThreshold = 6;
    private int _coinsReward = 100;

    void Start()
    {
        rewardButton.interactable = false;
        _correctButtonCount = 0;
        InvokeRepeating("ActivateNext", 0f, _activationDuration);
    }

    void ActivateNext()
    {
        _panels[_currentIndex].SetActive(false);
        _currentIndex = (_currentIndex + 1) % _panels.Length;
        _panels[_currentIndex].SetActive(true);
    }

    public void OnButtonClick(Button button)
    {
        if (IsCorrectButton(button))
        {
            _correctButtonCount++;
            if (_correctButtonCount >= _correctButtonThreshold)
            {
                StopSequence();
            }
            button.interactable = false;
        }
    }

    bool IsCorrectButton(Button button)
    {
        return button.tag == "GoldButton";
    }

    void StopSequence()
    {
        CancelInvoke("ActivateNext");
        rewardButton.interactable = true;
        GameManager.Instance.VolatileData.Coins += _coinsReward;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenReward : MonoBehaviour, IScreen
{
    [SerializeField] private TextMeshProUGUI _goldToReclaim;

    private Button[] _buttons;

    private void Awake()
    {
        _buttons = GetComponentsInChildren<Button>(true);

        ActivateButtons(true);
    }
    private void Start()
    {
        _goldToReclaim.enabled = true;
        _goldToReclaim.text = " 100 ";
    }

    void ActivateButtons(bool enable)
    {
        foreach (var button in _buttons)
        {
            button.interactable = enable;
        }
    }

    public void BTN_Back()
    {
        ScreenManager.Instance.Pop();
        _goldToReclaim.enabled = true;
        _goldToReclaim.text = " 100 ";
    }

    public void BTN_Claim(Button button)
    {
        _goldToReclaim.enabled = false;
        button.interactable = false;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        ActivateButtons(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        ActivateButtons(false);
    }

    public void Free()
    {
        //Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenRoot : MonoBehaviour, IScreen
{
    private HashSet<Behaviour> _enabledBehaviours = new();
    private Button[] _buttons;

    private void Awake()
    {
        _buttons = GetComponentsInChildren<Button>(true);
        ActivateButtons(true);
    }

    void ActivateButtons(bool enable)
    {
        foreach (var button in _buttons)
        {
            button.interactable = enable;
        }
    }

    public void BTN_PauseScreen()
    {
        ScreenManager.Instance.Push("Canvas - PauseController");
    }

    public void Activate()
    {
        ActivateButtons(true);
        RestoreBehaviours();
    }

    public void Deactivate()
    {
        DisableBehaviours();
        ActivateButtons(false);
    }

    public void Free()
    {
        //Destroy(gameObject);
    }

    private void DisableBehaviours()
    {
        foreach (Behaviour behaviour in gameObject.GetComponentsInChildren<Behaviour>())
        {
            _enabledBehaviours.Add(behaviour);
            if (behaviour.enabled)
            {
                _enabledBehaviours.Add(behaviour);
                behaviour.enabled = false;
            }
        }
    }

    private void RestoreBehaviours()
    {
        foreach (Behaviour behaviour in _enabledBehaviours)
            behaviour.enabled = true;
        _enabledBehaviours.Clear();
    }
}

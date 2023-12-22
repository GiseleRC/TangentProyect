using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Debugger : MonoBehaviour
{
    [SerializeField] private PanelButtonsBehaviour _panelBttBehaviour;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScreenManager.Instance.Pop();
        }
    }

    public void OpenMinigame()
    {
        ScreenManager.Instance.Push("Canvas - Minigame");
        _panelBttBehaviour.ResetValues();
    }

    public void OpenRewardScreen()
    {
        ScreenManager.Instance.Pop();
        ScreenManager.Instance.Push("Canvas - Reward");
    }
}
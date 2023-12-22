using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScreenExecuter : MonoBehaviour
{
    [SerializeField] private PanelButtonsBehaviour _panelBttBehaviour;

    public void Start()
    {
        ScreenManager.Instance.Push("Root");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScreenManager.Instance.Pop();
            ScreenManager.Instance.Push("Root");
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

    public void OpenPauseScreen()
    {
        ScreenManager.Instance.Pop();
        ScreenManager.Instance.Push("Canvas - PauseController");
    }

    public void OpenRootScreen() // ClosePauseMenu()
    {
        ScreenManager.Instance.Pop();
    }
}
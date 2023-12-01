using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Debugger : MonoBehaviour
{
    [SerializeField] private Transform _mainGameplay;
    [SerializeField] private Transform _miniGameplayPrefab;
    [SerializeField] private Transform _rewardScreenPrefab;

    void Start()
    {
        ScreenManager.Instance.Push(new ScreenGameplay(_mainGameplay));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScreenManager.Instance.Pop();
        }
    }

    public void OpenMinigame()
    {
        ScreenManager.Instance.Push(new ScreenGameplay(Instantiate(_miniGameplayPrefab)));
    }

    public void OpenRewardScreen()
    {
        ScreenManager.Instance.Push(new ScreenGameplay(Instantiate(_rewardScreenPrefab)));
    }
}
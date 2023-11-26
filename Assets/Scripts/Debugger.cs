using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Debugger : MonoBehaviour
{
    [SerializeField] private Transform _mainGameplay;

    [SerializeField] private Transform _miniGameplayPrefab;

    void Start()
    {
        ScreenManager.Instance.Push(new ScreenGameplay(_mainGameplay));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScreenManager.Instance.Push(new ScreenGameplay(Instantiate(_miniGameplayPrefab)));
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            var screenMinigame = Instantiate(Resources.Load<ScreenMinigame>("Canvas - Minigame"));
            ScreenManager.Instance.Push(screenMinigame);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScreenManager.Instance.Pop();
        }
    }
}

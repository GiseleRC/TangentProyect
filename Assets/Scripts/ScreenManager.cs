using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScreenManager : Singleton<ScreenManager>
{
    private Stack<IScreen> _screenStack;

    private void Awake()
    {
        _screenStack = new Stack<IScreen>();
    }

    public void Push(IScreen newScreen)
    {
        if (_screenStack.Count > 0)
        {
            _screenStack.Peek()
                        .Deactivate();
        }

        _screenStack.Push(newScreen);

        newScreen.Activate();
    }

    public void Push(string newScreenName)
    {
        var screenPrefab = Resources.Load<GameObject>(newScreenName);

        var instantiatedScreen = Instantiate(screenPrefab);

        if (instantiatedScreen.TryGetComponent(out IScreen screen))
        {
            Push(screen);
        }
    }

    public void Pop()
    {
        if (_screenStack.Count <= 1) return;

        _screenStack.Pop().Free();

        _screenStack.Peek().Activate();
    }
}

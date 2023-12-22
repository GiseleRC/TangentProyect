using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScreenManager : Singleton<ScreenManager>
{
    private Dictionary<string, IScreen> _screenByName;
    private Stack<IScreen> _screenStack;

    private void Awake()
    {
        _screenByName = new Dictionary<string, IScreen>();
        foreach (IScreen screen in FindObjectsOfType<MonoBehaviour>(true).OfType<IScreen>())
        {
            _screenByName[((MonoBehaviour)screen).gameObject.name] = screen;
        }

        _screenStack = new Stack<IScreen>();
    }

    public void Push(string screenName)
    {
        IScreen screen;
        if (_screenByName.TryGetValue(screenName, out screen))
            Push(screen);
    }

    private void Push(IScreen screen)
    {
        if (_screenStack.Count > 0)
            _screenStack.Peek().Deactivate();

        _screenStack.Push(screen);

        screen.Activate();
    }

    public void Pop()
    {
        if (_screenStack.Count <= 0) return;

        _screenStack.Pop().Deactivate();

        if (_screenStack.Count > 0)
            _screenStack.Peek().Activate();
    }
}

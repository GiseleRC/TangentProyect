using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenGameplay : IScreen
{
    private Transform _root;

    private Dictionary<Behaviour, bool> _beforeActivation;

    public ScreenGameplay(Transform root)
    {
        _root = root;

        _beforeActivation = new Dictionary<Behaviour, bool>();
    }

    public void Activate()
    {
        foreach (var pair in _beforeActivation)
        {
            pair.Key.enabled = pair.Value;
        }
    }

    public void Deactivate()
    {
        foreach (Behaviour behaviour in _root.GetComponentsInChildren<Behaviour>())
        {
            _beforeActivation[behaviour] = behaviour.enabled;

            behaviour.enabled = false;
        }
    }

    public void Free()
    {
        GameObject.Destroy(_root.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenGameplay : IScreen
{
    // Start is called before the first frame update
    private Transform _root;

    private Dictionary<Behaviour, bool> _beforeActivation;

    public ScreenGameplay(Transform root)
    {
        _root = root;

        _beforeActivation = new Dictionary<Behaviour, bool>();

        foreach (Transform child in root.transform)
        {
            child.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    public void Activate()
    {
        //Por cada Behaviour guardado previamente en el diccionario
        foreach (var pair in _beforeActivation)
        {
            //Accedo al enable de ese Behaviour y lo prendo o apago dependiendo lo que habia guardado en el Deactivate
            pair.Key.enabled = pair.Value;

            pair.Key.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    public void Deactivate()
    {
        //Por cada Behaviour como hijo del root
        foreach (Behaviour behaviour in _root.GetComponentsInChildren<Behaviour>())
        {
            //Guardamos en el diccionario si ese comportamiento estaba prendido o apagado
            _beforeActivation[behaviour] = behaviour.enabled;

            //Lo apago
            behaviour.enabled = false;

            behaviour.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    public void Free()
    {
        GameObject.Destroy(_root.gameObject);
    }
}

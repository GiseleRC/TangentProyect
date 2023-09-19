using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonController : MonoBehaviour
{
    public abstract void DisableGO(GameObject gameObject);

    public abstract void LoadScene(string scene);
}

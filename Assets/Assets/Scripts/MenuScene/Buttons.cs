using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class Buttons : ButtonController
{
    public override void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}

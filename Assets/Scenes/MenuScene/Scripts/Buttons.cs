using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class Buttons : ButtonController
{
    //[SerializeField] private AudioSource _selectSound;

    public override void DisableGO(GameObject gameObject)
    {
        if (gameObject)
        {
            gameObject.SetActive(false);
        }
    }

    public override void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}

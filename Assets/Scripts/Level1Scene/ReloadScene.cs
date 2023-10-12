using UnityEngine.SceneManagement;
using UnityEngine;

public class ReloadScene : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}

using UnityEngine.SceneManagement;
using UnityEngine;

public class ReloadScene : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

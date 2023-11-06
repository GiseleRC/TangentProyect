using UnityEngine.SceneManagement;
using UnityEngine;

public class ReloadScene : MonoBehaviour
{
    public void LoadThisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ScreenPauseController : MonoBehaviour, IScreen
{
    private Button[] _buttons;
    private void Awake()
    {
        _buttons = GetComponentsInChildren<Button>(true);

        ActivateButtons(true);
    }

    public void ReloadThisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        //Pause();
        ActivateButtons(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        //Unpause();
        ActivateButtons(false);
    }
    
    public void Free()
    {
        //
    }

    public void Pause()
    {
        //Time.timeScale = 0;
        GameManager.Instance.SavePersistentData();
    }

    public void Unpause()
    {
        //Time.timeScale = 1;
        GameManager.Instance.SavePersistentData();
    }

    public void ActivateButtons(bool enable)
    {
        foreach (var button in _buttons)
        {
            button.interactable = enable;
        }
    }
}
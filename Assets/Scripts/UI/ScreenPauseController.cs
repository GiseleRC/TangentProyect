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
        ActivateButtons(true);
        GameManager.Instance.SavePersistentData();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        ActivateButtons(false);
        GameManager.Instance.SavePersistentData();
    }
    
    public void Free()
    {
        //
    }

    public void ActivateButtons(bool enable)
    {
        foreach (var button in _buttons)
        {
            button.interactable = enable;
        }
    }
}
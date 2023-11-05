using UnityEngine;
using TMPro;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _playMenu;
    [SerializeField] private TextMeshProUGUI _pauseButtonText;

    public void Pause()
    {
        if (_pauseMenu.activeSelf)
        {
            _pauseMenu.SetActive(false);
            _playMenu.SetActive(true);
            Time.timeScale = 1;
            _pauseButtonText.text = "Pause";
        }
        else
        {
            _pauseMenu.SetActive(true);
            _playMenu.SetActive(false);
            Time.timeScale = 0;
            _pauseButtonText.text = "Unpause";
        }

        JsonSaveSystem.Instance.SaveGame();
    }
}
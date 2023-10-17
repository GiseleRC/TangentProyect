using UnityEngine;
using TMPro;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject playManu;
    [SerializeField] private TextMeshProUGUI pauseButtonText;

    public void Pause()
    {
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            playManu.SetActive(true);
            Time.timeScale = 1;
            pauseButtonText.text = "Pause";
        }
        else
        {
            pauseMenu.SetActive(true);
            playManu.SetActive(false);
            Time.timeScale = 0;
            pauseButtonText.text = "Unpause";
        }
    }
}
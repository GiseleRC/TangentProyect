using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button SelectLevelButton;
    [SerializeField] private Button ControlsButton;
    [SerializeField] private Button SelectLevelBackButton;
    [SerializeField] private Button ControlsBackButton;
    [SerializeField] private Button LoadScene1Button;
    [SerializeField] private Button LoadScene2Button;

    [SerializeField] private GameObject OptionsContainer;
    [SerializeField] private GameObject ControlsContainer;
    [SerializeField] private GameObject LevelsContainer;

    private void Start()
    {
        SelectLevelButton.onClick.AddListener(LevelsSelected);
        ControlsButton.onClick.AddListener(ControlsSelected);
        SelectLevelBackButton.onClick.AddListener(LevelsBackSelected);
        ControlsBackButton.onClick.AddListener(ControlsBackSelected);
        LoadScene1Button.onClick.AddListener(() => LoadScene("Level1"));
        LoadScene2Button.onClick.AddListener(() => LoadScene("Level2"));
    }

    private void ControlsSelected()
    {
        OptionsContainer.SetActive(false);
        ControlsContainer.SetActive(true);
        LevelsContainer.SetActive(false);
    }

    private void LevelsSelected()
    {
        OptionsContainer.SetActive(false);
        ControlsContainer.SetActive(false);
        LevelsContainer.SetActive(true);
    }

    private void ControlsBackSelected()
    {
        OptionsContainer.SetActive(true);
        ControlsContainer.SetActive(false);
    }

    private void LevelsBackSelected()
    {
        OptionsContainer.SetActive(true);
        LevelsContainer.SetActive(false);
    }

    private void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}

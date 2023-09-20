using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button SelectLevelButton;
    [SerializeField] private Button ControlsButton;
    [SerializeField] private Button CreditsButton;
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button SelectLevelBackButton;
    [SerializeField] private Button ControlsBackButton;
    [SerializeField] private Button CreditsBackButton;
    [SerializeField] private Button LoadScene1Button;
    [SerializeField] private Button LoadScene2Button;

    [SerializeField] private GameObject CreditsContainer;
    [SerializeField] private GameObject OptionsContainer;
    [SerializeField] private GameObject ControlsContainer;
    [SerializeField] private GameObject LevelsContainer;

    private void Start()
    {
        SelectLevelButton.onClick.AddListener(LevelsSelected);
        ControlsButton.onClick.AddListener(ControlsSelected);
        CreditsButton.onClick.AddListener(CreditsSelected);
        ExitButton.onClick.AddListener(ExitSelected);
        SelectLevelBackButton.onClick.AddListener(LevelsBackSelected);
        ControlsBackButton.onClick.AddListener(ControlsBackSelected);
        CreditsBackButton.onClick.AddListener(CreditsBackSelected);
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

    private void CreditsSelected()
    {
        OptionsContainer.SetActive(false);
        ControlsContainer.SetActive(false);
        LevelsContainer.SetActive(false);
        CreditsContainer.SetActive(true);
    }

    private void ExitSelected()
    {
        Application.Quit();
    }

    private void CreditsBackSelected()
    {
        OptionsContainer.SetActive(true);
        CreditsContainer.SetActive(false);
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

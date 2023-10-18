using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private SaveData _saveData;

    [SerializeField] private Button SelectLevelButton;
    [SerializeField] private Button ControlsButton;
    [SerializeField] private Button CreditsButton;
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button BackButton;
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
        BackButton.onClick.AddListener(BackSelected);
        LoadScene1Button.onClick.AddListener(() => LoadScene("Level1"));
        LoadScene2Button.onClick.AddListener(() => LoadScene("Level2"));
    }

    private void Update()
    {
        Level2Enable(JsonSaveSystem.Instance.Level1Winn);
    }
    private void LevelsSelected()
    {
        OptionsContainer.SetActive(false);
        LevelsContainer.SetActive(true);
        BackButton.gameObject.SetActive(true);
    }

    private void ControlsSelected()
    {
        OptionsContainer.SetActive(false);
        ControlsContainer.SetActive(true);
        BackButton.gameObject.SetActive(true);
    }

    private void CreditsSelected()
    {
        OptionsContainer.SetActive(false);
        CreditsContainer.SetActive(true);
        BackButton.gameObject.SetActive(true);
    }

    private void BackSelected()
    {
        OptionsContainer.SetActive(true);
        BackButton.gameObject.SetActive(false);
        LevelsContainer.SetActive(false);
        CreditsContainer.SetActive(false);
        ControlsContainer.SetActive(false);
    }

    private void Level2Enable(bool leve1Winn)
    {
        LoadScene2Button.gameObject.SetActive(leve1Winn);
    }

    private void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void ExitSelected()
    {
        Application.Quit();
    }
}
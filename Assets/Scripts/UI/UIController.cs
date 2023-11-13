using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button CreditsButton;
    [SerializeField] private Button ControlsButton;
    [SerializeField] private Button BackButton;
    [SerializeField] private Button SelectLevelButton;
    [SerializeField] private Button LoadScene1Button;
    [SerializeField] private Button LoadScene2Button;
    [SerializeField] private Button ConfirmDeleteDataButtom;
    [SerializeField] private Button YesButtom;
    [SerializeField] private Button NoButtom;

    [SerializeField] private GameObject CreditsContainer;
    [SerializeField] private GameObject OptionsContainer;
    [SerializeField] private GameObject ControlsContainer;
    [SerializeField] private GameObject LevelsContainer;
    [SerializeField] private GameObject ConfirmDeleteDataContainer;
    
    [SerializeField] private UIScreenController TutorialMenuContainer;

    private void Start()
    {
        ExitButton.onClick.AddListener(ExitSelected);
        CreditsButton.onClick.AddListener(CreditsSelected);
        ControlsButton.onClick.AddListener(ControlsSelected);
        BackButton.onClick.AddListener(BackSelected);

        SelectLevelButton.onClick.AddListener(LevelsSelected);
        LoadScene1Button.onClick.AddListener(() => SceneManager.LoadScene("Level1"));
        LoadScene2Button.onClick.AddListener(() => SceneManager.LoadScene("Level2"));
        
        ConfirmDeleteDataButtom.onClick.AddListener(DeleteConfirmationSelected);
        YesButtom.onClick.AddListener(DeleteConfirmed);
        NoButtom.onClick.AddListener(BackSelected);
    }

    private void Update()
    {
        Level2Enable(JsonSaveSystem.Instance.SaveData.reachedLevel >= 1);
    }

    public void EnableMenu(bool enable)
    {
        ExitButton.interactable = enable;
        CreditsButton.interactable = enable;
        ControlsButton.interactable = enable;
        BackButton.interactable = enable;
        SelectLevelButton.interactable = enable;
        LoadScene1Button.interactable = enable;
        LoadScene2Button.interactable = enable;
        ConfirmDeleteDataButtom.interactable = enable;
        YesButtom.interactable = enable;
        NoButtom.interactable = enable;
    }

    public void LevelsSelected()
    {
        OptionsContainer.SetActive(false);
        LevelsContainer.SetActive(true);
        BackButton.gameObject.SetActive(true);
        JsonSaveSystem.Instance.LoadGame();
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

    public void BackSelected()
    {
        OptionsContainer.SetActive(true);
        BackButton.gameObject.SetActive(false);
        LevelsContainer.SetActive(false);
        CreditsContainer.SetActive(false);
        ControlsContainer.SetActive(false);
        ConfirmDeleteDataContainer.SetActive(false);
    }

    public void DeleteConfirmationSelected()
    {
        ConfirmDeleteDataContainer.SetActive(true);
        OptionsContainer.SetActive(false);
        JsonSaveSystem.Instance.LoadGame();
    }

    public void DeleteConfirmed()
    {
        ConfirmDeleteDataContainer.SetActive(false);
        OptionsContainer.SetActive(true);

        JsonSaveSystem.Instance.DeleteGame();
        TutorialMenuContainer.gameObject.SetActive(true);
        TutorialMenuContainer.PlayTutorial();
    }

    private void Level2Enable(bool leve1Winn)
    {
        LoadScene2Button.gameObject.SetActive(leve1Winn);
    }

    private void ExitSelected()
    {
        Application.Quit();
    }
}
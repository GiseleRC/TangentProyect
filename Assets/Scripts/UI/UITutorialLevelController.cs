using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITutorialLevelController : MonoBehaviour
{
    [SerializeField] private Button GetTurret1;
    [SerializeField] private Button GetTurret2;
    [SerializeField] private Button StartNextWave;
    [SerializeField] private Button ReloadScene;

    [SerializeField] private GameObject _tutorialLevelGO;
    [SerializeField] private GameObject _firstSection;
    [SerializeField] private GameObject _secondSection;
    [SerializeField] private GameObject _thirdSection;
    [SerializeField] private GameObject _fourthSection;
    [SerializeField] private GameObject _fifthSection;

    private GameObject _currSection;

    private void Start()
    {
        _tutorialLevelGO.SetActive(true);

        GameManager.Instance.LoadPersistentData();
        if (!GameManager.Instance.PersistentData.tutorialLevelCompleted)
        {
            PlayLevelTutorial();
        }
        else
        {
            _tutorialLevelGO.SetActive(false);
        }

        EnableMenu(GameManager.Instance.PersistentData.tutorialLevelCompleted);
    }

    public void PlayLevelTutorial()
    {
        _firstSection.SetActive(true);
        _tutorialLevelGO.SetActive(true);

        _currSection = _firstSection;

        EventManager.TriggerEvent(EventType.TutorialLevelStarted);
    }

    private void EndTutorial()
    {
        gameObject.SetActive(false);

        EventManager.TriggerEvent(EventType.TutorialLevelCompleted);
    }

    public void EnableMenu(bool enable)
    {
        GetTurret1.interactable = enable;
        GetTurret2.interactable = enable;
        StartNextWave.interactable = enable;
        ReloadScene.interactable = enable;
    }

    public void CloseSection()
    {
        if (_currSection == _firstSection)
        {
            _currSection.SetActive(false);
            _secondSection.SetActive(true);

            _currSection = _secondSection;
        }
        else if (_currSection == _secondSection)
        {
            _currSection.SetActive(false);
            _thirdSection.SetActive(true);

            _currSection = _thirdSection;
        }
        else if (_currSection == _thirdSection)
        {
            _currSection.SetActive(false);
            _fourthSection.SetActive(true);

            _currSection = _fourthSection;
        }
        else if (_currSection == _fourthSection)
        {
            _currSection.SetActive(false);
            _fifthSection.SetActive(true);

            _currSection = _fifthSection;
        }
        else if (_currSection == _fifthSection)
        {
            _currSection.SetActive(false);
            GameManager.Instance.PersistentData.tutorialLevelCompleted = true;
            EnableMenu(GameManager.Instance.PersistentData.tutorialLevelCompleted);
            GameManager.Instance.SavePersistentData();
            EndTutorial();
        }
    }
}

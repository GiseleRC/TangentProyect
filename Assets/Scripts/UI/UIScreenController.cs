using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScreenController : MonoBehaviour
{
    [SerializeField] private UIController _uIController;
    [SerializeField] private GameObject _tutorialImageGO;
    [SerializeField] private GameObject _firstSection;
    [SerializeField] private GameObject _secondSection;
    [SerializeField] private GameObject _thirdSection;

    private GameObject _currSection;

    private void Start()
    {
        _tutorialImageGO.SetActive(true);
        JsonSaveSystem.Instance.LoadGame();
        if (!JsonSaveSystem.Instance._tutorialMenu)
        {
            PlayTutorial();
        }
        else
        {
            _tutorialImageGO.SetActive(false);
        }
    }

    public void PlayTutorial()
    {
        _uIController.EnableMenu(false);
        _firstSection.SetActive(true);
        _tutorialImageGO.SetActive(true);

        _currSection = _firstSection;
    }

    private void EndTutorial()
    {
        JsonSaveSystem.Instance._tutorialMenu = true;
        _uIController.EnableMenu(true);
        gameObject.SetActive(false);
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
            EndTutorial();
        }
    }
}

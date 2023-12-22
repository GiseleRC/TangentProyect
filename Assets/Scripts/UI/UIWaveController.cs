using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIWaveController : MonoBehaviour
{
    [SerializeField] private Text _textWave;
    [SerializeField] private Button _startWave;
    [SerializeField] private Button _nextWave;
    [SerializeField] private EnemySpawner _waveSpawner;

    private void Awake()
    {
        EventManager.TriggerEvent(EventType.LevelStarted, SceneManager.GetActiveScene().buildIndex);
    }
    private void Start()
    {
        _waveSpawner.enabled = false;
        _startWave.onClick.AddListener(StartWaveButton);
    }
    
    private void StartWaveButton()
    {
        _waveSpawner.enabled = true;
    }
}

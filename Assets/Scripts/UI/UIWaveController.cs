using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWaveController : WaveSpawner
{
    [SerializeField] private Text _textWave;
    [SerializeField] private Button _startWave;
    [SerializeField] private Button _nextWave;

    private void Start()
    {
        //_startWave.onClick.AddListener(StartWave);
        //_nextWave.onClick.AddListener(EndSpawn);
    }
}

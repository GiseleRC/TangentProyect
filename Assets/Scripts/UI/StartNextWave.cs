using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartNextWave : MonoBehaviour
{
    public WaveSpawner waveSpawner;
    public TMP_Text startNextWaveText;

    private void Awake()
    {
        //waveSpawner.waveCountdownText.text = "Press Start Wave";
    }

    public void StartWave()
    {
        if (waveSpawner.isActiveAndEnabled)
        {
            //waveSpawner.NextWaveEarly();
        }
        else
        {
            waveSpawner.enabled = true;
            startNextWaveText.text = "Next Wave";
        }
    }
}
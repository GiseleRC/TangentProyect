using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _timeBetweenWaves = 5f;
    private float _countdown = 2f;// HACER --------- usarlo para un slide donde se vea como va descontandose el tiempo antes de la siguiente wave
    private int _waveIndex = 0;
    private float _secondsToWaitWave = 0.5f;
    private string _waveText = "Wave: ";

    public TMP_Text waveCountdownText;

    void Update()
    {
        StartWave();
        _countdown -= Time.deltaTime;
    }

    //Corrutina para leer los datos de la colección
    IEnumerator SpawnWave()
    {
        _waveIndex++;
        for (int i = 0; i < _waveIndex; i++)
        {
            waveCountdownText.text = (_waveText + _waveIndex.ToString());
            SpawnEnemy();
            yield return new WaitForSeconds(_secondsToWaitWave);
        }
    }

    private void StartWave()
    {
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = _timeBetweenWaves;
        }
    }

    private void SpawnEnemy()
    {
        if (Random.Range(0, 101) <= 65)
        {
            EnemyBasicFactory.Instance.GetObjectFromPool();
        }
        else
        {
            EnemyHeavyFactory.Instance.GetObjectFromPool();
        }
    }

    public void NextWaveEarly()
    {
        _countdown = 0;
    }
}
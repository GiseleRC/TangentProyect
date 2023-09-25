using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform _enemyPrefab;
    public Transform _spawnPoint;
    public TMP_Text waveCountdownText;
    public float _timeBetweenWaves = 5f;

    private float _countdown = 2f;
    private int _waveIndex = 0;

    void Update()
    {
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = _timeBetweenWaves;
        }

        _countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(_countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        _waveIndex++;
        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }
}

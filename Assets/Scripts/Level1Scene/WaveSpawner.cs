using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform _enemyBasicPrefab;
    [SerializeField] private Transform _enemyHeavyPrefab;
    private Transform _enemyToSpawn;
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
        if (Random.Range(0, 101) <= 65)
        {
            _enemyToSpawn = _enemyBasicPrefab;
        }
        else
        {
            _enemyToSpawn = _enemyHeavyPrefab;
        }
        Instantiate(_enemyToSpawn, _spawnPoint.position, _spawnPoint.rotation);
    }
}

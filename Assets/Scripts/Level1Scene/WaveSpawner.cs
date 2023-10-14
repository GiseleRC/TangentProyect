using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _timeBetweenWaves = 5f;
    [SerializeField] private Transform _enemyBasicPrefab;
    [SerializeField] private Transform _enemyHeavyPrefab;
    private Transform _enemyToSpawn;
    private float _countdown = 2f;
    private int _waveIndex = 0;
    private float _secondsToWaitWave = 0.5f;

    public TMP_Text waveCountdownText;

    void Update()
    {
        StartWave();
        _countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(_countdown).ToString();
    }

    //Corrutina para leer los datos de la colección
    IEnumerator SpawnWave()
    {
        _waveIndex++;
        for (int i = 0; i < _waveIndex; i++)
        {
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

    //Nico
    private void SpawnEnemy()
    {
        if (Random.Range(0, 101) <= 65)
        {
            EnemyBasicFactory.Instance.GetObjectFromPool();
            //EnemyBasicFactory.Instance.GetObjectFromPool(EnemyBasicFactory.TypeEnemy.Basic);
            //_enemyToSpawn = _enemyBasicPrefab;
        }
        else
        {
            EnemyHeavyFactory.Instance.GetObjectFromPool();
            //EnemyBasicFactory.Instance.GetObjectFromPool(EnemyBasicFactory.TypeEnemy.Heavy);
            //_enemyToSpawn = _enemyHeavyPrefab;
        }
        //Instantiate(_enemyToSpawn, _spawnPoint.position, _spawnPoint.rotation);
    }

    public void NextWaveEarly()
    {
        _countdown = 0;
    }
}
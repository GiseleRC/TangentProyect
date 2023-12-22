using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    private class Wave
    {
        [SerializeField] private float _duration;
        [SerializeField] private float _timeBetweenSpawns;
        [SerializeField] private float _heavyProbability;

        private float _durationT = 0.0f;
        private float _timeBetweenSpawnsT = 0.0f;

        internal bool Update(Transform spawnPoint)
        {
            if (_durationT > _duration)
                return true;

            _durationT += Time.deltaTime;
            _timeBetweenSpawnsT += Time.deltaTime;
            if (_timeBetweenSpawnsT > _timeBetweenSpawns)
            {
                _timeBetweenSpawnsT -= _timeBetweenSpawns;
                if (Random.Range(0.0f, 1.0f) < _heavyProbability)
                {
                    Enemy spawnedEnemy = EnemyHeavyFactory.Instance.GetObjectFromPool();
                    spawnedEnemy.transform.position = spawnPoint.transform.position;
                    Debug.Log("Spawning Heavy Enemy");
                }
                else
                {
                    Enemy spawnedEnemy = EnemyBasicFactory.Instance.GetObjectFromPool();
                    spawnedEnemy.transform.position = spawnPoint.transform.position;
                    Debug.Log("Spawning Basic Enemy");
                }
            }

            return false;
        }
    }



    [SerializeField] public Transform _spawnPoint;
    [SerializeField] private float _timeBetweenWaves;
    [SerializeField] private Wave[] _waves;

    private int _waveIdx;
    private float _timeBetweenWavesT;

    private void Start()
    {
        _waveIdx = 0;
        _timeBetweenWavesT = 0.0f;
        Debug.Log("Enemy Spawner Start");
    }

    private void Update()
    {
        StartWave();
    }

    void StartWave()
    {
        if (_waveIdx >= _waves.Length)
        {
            enabled = false;
            EventManager.TriggerEvent(EventType.LevelEnded, SceneManager.GetActiveScene().buildIndex, true);
            UIvictory.Instance.WonScreen();
            return;
        }

        if (_waves[_waveIdx].Update(_spawnPoint))
        {
            _timeBetweenWavesT += Time.deltaTime;
            if (_timeBetweenWavesT > _timeBetweenWaves)
            {
                _timeBetweenWavesT -= _timeBetweenWavesT;
                ++_waveIdx;
                Debug.Log("Next Wave");
            }
        }
    }
}
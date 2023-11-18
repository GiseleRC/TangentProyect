using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float _timeBetweenWaves = 5f;

    private int _waveIndex = 0;
    private float _secondsToWaitWave = 0.5f;
    private string _waveText = "Wave: ";

    public TMP_Text waveCountdownText;

    [SerializeField] private int _enemiesInitialNumber;
    private int _roundIndex = 1;
    private int _remainingEnemiesInWave;
    private bool _spawningEnemies = false;

    public Transform _spawnPoint;

    private void Awake()
    {
        EventManager.TriggerEvent(EventType.LevelStarted, SceneManager.GetActiveScene().buildIndex);

        if (waveCountdownText == null)
        {
            waveCountdownText = GameObject.Find("WaveCountdownTimer").GetComponent<TMP_Text>();
        }
    }

    void Update()
    {
        StartWave();
    }

    private void StartWave()
    {
        if (!_spawningEnemies)
        {
            if (_waveIndex >= 3)
            {
                _roundIndex++;

                if(_roundIndex > 3)
                {
                    EventManager.TriggerEvent(EventType.LevelEnded, SceneManager.GetActiveScene().buildIndex, true);
                    _spawningEnemies = true;
                    UIvictory.Instance.WonScreen();
                    return;
                }

                _waveIndex = 0;
            }
            StartCoroutine(SpawnWaveTest());
        }
    }

    IEnumerator SpawnWaveTest()
    {
        _spawningEnemies = true;
        _waveIndex++;
        _remainingEnemiesInWave = _enemiesInitialNumber;
        waveCountdownText.text = (_waveText + _waveIndex.ToString());

        while (_remainingEnemiesInWave > 0) // Al número inicial de enemigos los divido en grupos aleatorios que no sean mayores a la mitad del número inicial, ni a la cantidad de enemigos restantes
        {
            int enemiesInThisGroupOfTheWave = Mathf.Clamp(Random.Range(1, _enemiesInitialNumber / 2), 1, _remainingEnemiesInWave);
            _remainingEnemiesInWave -= enemiesInThisGroupOfTheWave;

            StartCoroutine(SpawnGroup(enemiesInThisGroupOfTheWave));
            yield return new WaitForSeconds(_secondsToWaitWave * 4); // Tiempo entre grupo y grupo
        }
        yield return new WaitForSeconds(_timeBetweenWaves);
        _spawningEnemies = false;
    }

    IEnumerator SpawnGroup(int enemiesAmount) // Spawnea al grupo completo antes de seguir con la oleada
    {
        for (int i = 0; i < enemiesAmount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_secondsToWaitWave);
        }
    }

    private void SpawnEnemy()
    {
        if (Random.Range(0, 101) <= 100 - _waveIndex * 10 - (_roundIndex - 1) * 25)
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
        //_countdown = 0;
    }
}
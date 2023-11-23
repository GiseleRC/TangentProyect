using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDeath : MonoBehaviour
{
    public static UIDeath Instance { get; private set; }

    [SerializeField] private AudioSource _inbase;
    [SerializeField] private GameObject deathCanvas;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Slider _livesValue;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        _inbase.volume = 0.5f;
    }

    public void BaseDamage(int damage)
    {
        if (damage > 0 && GameManager.Instance.VolatileData.Lives > 0)
        {
            _inbase.Play();
            GameManager.Instance.VolatileData.Lives -= damage;
            Instance_OnLivesChanged(GameManager.Instance.VolatileData.Lives);
        }
        if (GameManager.Instance.VolatileData.Lives <= 0)
        {
            deathCanvas.SetActive(true);
            _inbase.volume = 0f;
        }
    }

    private void Instance_OnLivesChanged(int lives)
    {
        _text.text = lives + " /10";
        _livesValue.value = lives;
    }
}
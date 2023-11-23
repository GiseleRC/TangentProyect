using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDeath : MonoBehaviour
{
    public static UIDeath Instance { get; private set; }
    
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
    }

    public void BaseDamage(int damage)
    {
        if (damage > 0 && GameManager.Instance.VolatileData.Lives > 0)
        {
            GameManager.Instance.VolatileData.Lives -= damage;
            Instance_OnLivesChanged(GameManager.Instance.VolatileData.Lives);
        }
        if (GameManager.Instance.VolatileData.Lives <= 0)
        {
            deathCanvas.SetActive(true);
        }
    }

    private void Instance_OnLivesChanged(int lives)
    {
        _text.text = lives + " /10";
        _livesValue.value = lives;
    }
}
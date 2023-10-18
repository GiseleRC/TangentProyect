using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDeath : MonoBehaviour
{
    public static UIDeath Instance { get; private set; }
    
    [SerializeField] private GameObject deathCanvas;

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
        if (damage > 0 && GameManager.Instance.Lifes > 0)
        {
            GameManager.Instance.Lifes -= damage;
        }
        if (GameManager.Instance.Lifes <= 0)
        {
            deathCanvas.SetActive(true);
        }
    }
}
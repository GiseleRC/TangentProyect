using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIvictory : MonoBehaviour
{
    public static UIvictory Instance { get; private set; }

    [SerializeField] private GameObject victoryCanvas;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void WonScreen()
    {
        victoryCanvas.SetActive(true);
    }
}

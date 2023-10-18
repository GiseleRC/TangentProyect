using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWin : MonoBehaviour
{
    public static UIWin Instance { get; private set; }

    [SerializeField] private GameObject winCanvas;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void WinScreen()
    {
        winCanvas.SetActive(true);
    }
}

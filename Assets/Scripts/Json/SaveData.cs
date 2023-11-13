using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public int currency = 0;
    public int reachedLevel = 0;
    public bool tutorialMenu = false;

    public void Reset()
    {
        currency = 0;
        reachedLevel = 0;
        tutorialMenu = false;
    }
}

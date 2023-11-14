using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PersistentData
{
    public int orbs = 0;
    public int reachedLevel = 0;
    public bool tutorialMenu = false;

    public void Reset()
    {
        orbs = 0;
        reachedLevel = 0;
        tutorialMenu = false;
    }
}

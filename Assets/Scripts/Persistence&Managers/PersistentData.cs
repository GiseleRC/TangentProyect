using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PersistentData
{
    [SerializeField] private int orbs = 0;
    [SerializeField] private int mana = 300;
    [SerializeField] private int reachedLevel = 0;
    [SerializeField] private int currentAvatar = 0;

    public bool tutorialCompleted = false;

    public int Orbs { get => orbs; set { orbs = value; OnOrbsChanged?.Invoke(orbs); } }
    public int Mana { get => mana; set { mana = value; OnManaChanged?.Invoke(mana); } }
    public int ReachedLevel { get => reachedLevel; set { reachedLevel = value; OnReachedLevelChanged?.Invoke(reachedLevel); } }
    public int CurrentAvatar { get => currentAvatar; set { currentAvatar = value; OnAvatarChanged?.Invoke(currentAvatar); } }


    public delegate void OrbsChangedHandler(int orbs);
    public event OrbsChangedHandler OnOrbsChanged;

    public delegate void ManaChangedHandler(int mana);
    public event ManaChangedHandler OnManaChanged;

    public delegate void ReachedLevelChangedHandler(int reachedLevel);
    public event ReachedLevelChangedHandler OnReachedLevelChanged;

    public delegate void AvatarChangedHandler(int avatar);
    public event AvatarChangedHandler OnAvatarChanged;


    public void Reset()
    {
        Mana = 300;
        Orbs = 0;
        ReachedLevel = 0;
        tutorialCompleted = false;
        CurrentAvatar = 0;
    }
}

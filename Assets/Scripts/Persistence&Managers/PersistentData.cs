using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PersistentData
{
    [SerializeField] private int orbs = 0;
    [SerializeField] private int mana = 3;
    [SerializeField] private int reachedLevel = 0;
    [SerializeField] private int currentAvatar = 0;
    [SerializeField] private float volumeValue = 1f;
    [SerializeField] private DateTime _nextManaTime;
    [SerializeField] private DateTime _lastManaTime;

    public bool tutorialCompleted = false;
    public bool tutorialLevelCompleted = false;

    public int Orbs { get => orbs; set { orbs = value; OnOrbsChanged?.Invoke(orbs); } }
    public int Mana { get => mana; set { mana = value; OnManaChanged?.Invoke(mana); } }
    public int ReachedLevel { get => reachedLevel; set { reachedLevel = value; OnReachedLevelChanged?.Invoke(reachedLevel); } }
    public int CurrentAvatar { get => currentAvatar; set { currentAvatar = value; OnAvatarChanged?.Invoke(currentAvatar); } }
    public float VolumeValue { get => volumeValue; set { volumeValue = value; OnVolumeChanged?.Invoke(volumeValue); } }
    public DateTime NextManaTime { get => _nextManaTime; set { _nextManaTime = value; OnNextManaTimeChanged?.Invoke(_nextManaTime); } }
    public DateTime LastManaTime { get => _lastManaTime; set { _lastManaTime = value; OnLastManaTimeChanged?.Invoke(_lastManaTime); } }

    public delegate void OrbsChangedHandler(int orbs);
    public event OrbsChangedHandler OnOrbsChanged;

    public delegate void ManaChangedHandler(int mana);
    public event ManaChangedHandler OnManaChanged;

    public delegate void ReachedLevelChangedHandler(int reachedLevel);
    public event ReachedLevelChangedHandler OnReachedLevelChanged;

    public delegate void AvatarChangedHandler(int avatar);
    public event AvatarChangedHandler OnAvatarChanged;

    public delegate void VolumeValueChangedHandler(float volume);
    public event VolumeValueChangedHandler OnVolumeChanged;

    public delegate void NextManaTimeChanged(DateTime nextManaTime);
    public event NextManaTimeChanged OnNextManaTimeChanged;

    public delegate void LastManaTimeChanged(DateTime lastManaTime);
    public event LastManaTimeChanged OnLastManaTimeChanged;

    public void Reset()
    {
        Mana = 3;
        Orbs = 0;
        ReachedLevel = 0;
        CurrentAvatar = 0;
        VolumeValue = 1f;
        tutorialCompleted = false;
        tutorialLevelCompleted = false;
    }
}

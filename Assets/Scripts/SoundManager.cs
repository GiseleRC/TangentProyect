using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    //Volume controller slider menu option

    [SerializeField] private AudioSource _buttonsSound;
    [SerializeField] private AudioSource _backgroundSound;
    [SerializeField] private Slider sliderVolumen;

    private void Start()
    {
        sliderVolumen.value = GameManager.Instance.PersistentData.VolumeValue;
    }

    public void VolumeChanger()
    {
        _backgroundSound.volume = sliderVolumen.value;
        _buttonsSound.volume = sliderVolumen.value;

        UpdateVolume(sliderVolumen.value);
    }

    public void PLayButtonSound()
    {
        _buttonsSound.Play();
    }

    public void UpdateVolume(float volume)
    {
        GameManager.Instance.PersistentData.VolumeValue = volume;
        GameManager.Instance.SavePersistentData();
    }
}

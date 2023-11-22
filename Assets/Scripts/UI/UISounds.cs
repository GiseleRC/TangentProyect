using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISounds : MonoBehaviour
{
    [SerializeField] private AudioSource buttonSound;

    public void PlaySoundButton()
    {
        buttonSound.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DecoratorActioner : MonoBehaviour
{
    [SerializeField] private GameObject _panelButton;
    [SerializeField] private TextMeshPro _description;
    [SerializeField] private ParticleSystem _particleFire;
    [SerializeField] private ParticleSystem _particleIce;

    private void Start()
    {
        _description.gameObject.SetActive(true);

        Invoke("TextOff", 3f);
        _particleIce.gameObject.SetActive(false);
        _particleFire.gameObject.SetActive(false);
    }
    public void GetSimpleIceShoot(Turret _myTurret)
    {
        _myTurret = new SimpleIceShoot(_myTurret);
        _myTurret.ImpactEffect();//no implementado

        _description.text = _myTurret.GetDescription() + " Area hit is: " + _myTurret.AreaHit();
        _panelButton.SetActive(false);
        _particleIce.gameObject.SetActive(true);
    }

    public void GetDoubleFireShoot(Turret _myTurret)
    {
        _myTurret = new DoubleFireShoot(_myTurret);
        _myTurret.ImpactEffect();//no implementado

        _description.text = _myTurret.GetDescription() + " Area hit is: "  + _myTurret.AreaHit();
        _panelButton.SetActive(false);
        _particleFire.gameObject.SetActive(true);
    }

    private void OnMouseDown()
    {
        _panelButton.SetActive(true);
    }

    private void TextOff()
    {
        _description.gameObject.SetActive(false);
        _description.text = " ";
        _particleIce.gameObject.SetActive(false);
        _particleFire.gameObject.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TurretDecoratorDebugger : MonoBehaviour
{
    [SerializeField] private GameObject _panelButton;
    [SerializeField] private TextMeshPro _description;

    private void Start()
    {
        _description.gameObject.SetActive(true);

        Invoke("TextOff", 3f);
    }
    public void GetSimpleIceShoot(Turret _myTurret)
    {
        _myTurret = new SimpleIceShoot(_myTurret);
        _myTurret.ImpactEffect();
        _myTurret.AreaHit();

        _description.text = _myTurret.GetDescription();
        _panelButton.SetActive(false);
    }

    public void GetDoubleFireShoot(Turret _myTurret)
    {
        _myTurret = new DoubleFireShoot(_myTurret);
        _myTurret.ImpactEffect();
        _myTurret.AreaHit();

        _description.text = _myTurret.GetDescription();
        _panelButton.SetActive(false);
    }

    private void OnMouseDown()
    {
        _panelButton.SetActive(true);
    }

    private void TextOff()
    {
        _description.gameObject.SetActive(false);
        _description.text = " ";
    }
}
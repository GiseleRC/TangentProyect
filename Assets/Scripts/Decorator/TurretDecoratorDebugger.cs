using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurretDecoratorDebugger : MonoBehaviour
{
    [SerializeField] private GameObject _panelButton;

    public void GetSimpleIceShoot(Turret _myTurret)
    {
        _myTurret = new SimpleIceShoot(_myTurret);
        _myTurret.ImpactEffect();
        _myTurret.GetDescription();
        _myTurret.AreaHit();

        Debug.Log(" " + _myTurret.GetDescription() + " " + _myTurret.AreaHit() + " ");
        _panelButton.SetActive(false);
    }

    public void GetDoubleFireShoot(Turret _myTurret)
    {
        _myTurret = new DoubleFireShoot(_myTurret);
        _myTurret.ImpactEffect();
        _myTurret.GetDescription();
        _myTurret.AreaHit();

        Debug.Log(" " + _myTurret.GetDescription() + " " + _myTurret.AreaHit() + " ");
        _panelButton.SetActive(false);
    }

    private void OnMouseDown()
    {
        _panelButton.SetActive(true);
    }
}

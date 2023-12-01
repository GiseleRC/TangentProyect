using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurretDecoratorDebugger : MonoBehaviour
{
    private void Awake()
    {
        Turret _myTurret = new TurretWithPanels();

        Debug.Log($"Weapon: {_myTurret.GetDescription()}, Damage: {_myTurret.AreaHit()}");

        _myTurret = new DoubleFireShoot(_myTurret);

        _myTurret.ImpactEffect();

        Debug.Log($"Weapon: {_myTurret.GetDescription()}, Damage: {_myTurret.AreaHit()}");

        _myTurret = _myTurret.PreviousTurret;

        _myTurret = new SimpleIceShoot(_myTurret);

        _myTurret = new SimpleIceShoot(_myTurret);
        _myTurret = new SimpleIceShoot(_myTurret);
        _myTurret = new SimpleIceShoot(_myTurret);
        _myTurret = new SimpleIceShoot(_myTurret);

        Debug.Log($"Weapon: {_myTurret.GetDescription()}, Damage: {_myTurret.AreaHit()}");
        _myTurret.ImpactEffect();
    }
}

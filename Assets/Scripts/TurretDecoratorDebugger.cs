using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurretDecoratorDebugger : MonoBehaviour
{
    private void Awake()
    {
        Turret _mySword = new TurretWithPanels();

        Debug.Log($"Weapon: {_mySword.GetDescription()}, Damage: {_mySword.AreaHit()}");

        _mySword = new DoubleFireShoot(_mySword);

        _mySword.ImpactEffect();

        Debug.Log($"Weapon: {_mySword.GetDescription()}, Damage: {_mySword.AreaHit()}");

        _mySword = _mySword.PreviousTurret;

        _mySword = new SimpleIceShoot(_mySword);

        _mySword = new SimpleIceShoot(_mySword);
        _mySword = new SimpleIceShoot(_mySword);
        _mySword = new SimpleIceShoot(_mySword);
        _mySword = new SimpleIceShoot(_mySword);

        Debug.Log($"Weapon: {_mySword.GetDescription()}, Damage: {_mySword.AreaHit()}");
        _mySword.ImpactEffect();
    }
}

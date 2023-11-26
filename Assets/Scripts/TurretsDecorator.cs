using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretsDecorator : Turret
{
    protected Turret _turretPrefab;

    public TurretsDecorator(Turret turret)
    {
        PreviousTurret = _turretPrefab = turret;
    }
}

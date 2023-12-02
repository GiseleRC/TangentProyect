using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretsDecorator : Turret
{
    protected Turret _turret;

    public TurretsDecorator(Turret turret)
    {
        PreviousTurret = _turret = turret;
    }
}
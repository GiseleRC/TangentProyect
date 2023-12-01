using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret
{
    protected string _description;

    public Turret PreviousTurret { get; protected set; }

    public abstract string GetDescription();

    public abstract int AreaHit();

    public abstract void ImpactEffect();
}

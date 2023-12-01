using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSimple : Turret
{
    public TurretSimple()
    {
        PreviousTurret = this;
    }

    public override string GetDescription()
    {
        return "Turret simple";
    }

    public override int AreaHit()
    {
        return 0;
    }

    public override void ImpactEffect()
    {
        //none impact
    }
}

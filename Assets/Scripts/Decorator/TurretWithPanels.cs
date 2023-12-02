using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretWithPanels : Turret
{
    public TurretWithPanels()
    {
        PreviousTurret = this;
    }

    public override string GetDescription()
    {
        return "Turret with panels";
    }

    public override int AreaHit()
    {
        return 30;
    }

    public override void ImpactEffect()
    {
        //none impact
    }
}
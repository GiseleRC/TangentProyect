using UnityEngine;

public class Shop : Singleton<Shop>
{
    public TurretBlueprints turret1;
    public TurretBlueprints turret2;
    public ObstacleStats obstaclesStats;

    public void PurchasesTurret1()
    {
        BuildManager.Instance.SelectTurretToBuild(turret1);
    }

    public void PurchasesTurret2()
    {
        BuildManager.Instance.SelectTurretToBuild(turret2);
    }
    public void PurchasesAxe()
    {
        BuildManager.Instance.SelectTurretToBuild(null);
        obstaclesStats.axeSelected = true;
    }

    public void PurchasePowerUp()
    {
        //activo un power up
    }
}

using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprints turret1;
    public TurretBlueprints turret2;
    public ObstacleStats obstaclesStats;

    public static Shop Instance { get; private set; }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

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

    public void EnablePowerUp()
    {
        //activo un power up
    }
}

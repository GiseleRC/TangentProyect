using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprints turret1;
    public TurretBlueprints turret2;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchasesTurret1()
    {
        buildManager.SelectTurretToBuild(turret1);
    }

    public void PurchasesTurret2()
    {
        buildManager.SelectTurretToBuild(turret2);
    }
}

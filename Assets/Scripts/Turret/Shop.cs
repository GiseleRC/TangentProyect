using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprints turret1;
    public TurretBlueprints turret2;

    public void PurchasesTurret1()
    {
        BuildManager.Instance.SelectTurretToBuild(turret1);
    }

    public void PurchasesTurret2()
    {
        BuildManager.Instance.SelectTurretToBuild(turret2);
    }
}

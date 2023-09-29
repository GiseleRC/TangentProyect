using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchasesTurret1()
    {
        buildManager.SetTurretToBuild(buildManager.turret1Prefab);
    }

    public void PurchasesTurret2()
    {
        buildManager.SetTurretToBuild(buildManager.turret2Prefab);
    }

    void Update()
    {
        
    }
}

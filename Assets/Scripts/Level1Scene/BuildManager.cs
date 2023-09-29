using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public GameObject turret1Prefab;
    public GameObject turret2Prefab;

    private TurretBlueprints turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position + node.positionOffset, node.transform.rotation);
        node.turret = turret;
    }

    public void SelectTurretToBuild(TurretBlueprints turret)
    {
        turretToBuild = turret;
    }

}

using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [SerializeField] private GameObject _turret1Prefab;
    [SerializeField] private GameObject _turret2Prefab;
    private TurretBlueprints _turretToBuild;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public bool CanBuild { get { return _turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < _turretToBuild.cost)
        {
            return;
        }
        PlayerStats.Money -= _turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(_turretToBuild.prefab, node.transform.position + node.positionOffset, node.transform.rotation);
        node.turret = turret;
    }

    public void SelectTurretToBuild(TurretBlueprints turret)
    {
        _turretToBuild = turret;
    }

}

using UnityEngine;

public class BuildManager : Singleton<BuildManager>
{
    [SerializeField] private AudioSource _putTurret;
    [SerializeField] private GameObject _turret1Prefab;
    [SerializeField] private GameObject _turret2Prefab;
    [SerializeField] protected Transform _root = null;
    private TurretBlueprints _turretToBuild;

    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool HasMoney { get { return GameManager.Instance.VolatileData.Coins >= _turretToBuild.cost; } }
    public bool HasMoneyToObstacles { get { return GameManager.Instance.VolatileData.Coins >= Shop.Instance.obstaclesStats.cost; } }

    public void RemoveObstacles(Obstacles obstacle)
    {
        if (GameManager.Instance.VolatileData.Coins < Shop.Instance.obstaclesStats.cost)
        {
            return;
        }
        GameManager.Instance.VolatileData.Coins -= Shop.Instance.obstaclesStats.cost;
        _putTurret.Play();
        obstacle.node.GetComponent<Collider>().enabled = true;
    }

    public void BuildTurretOn(Node node)
    {
        if (GameManager.Instance.VolatileData.Coins < _turretToBuild.cost)
        {
            return;
        }
        GameManager.Instance.VolatileData.Coins -= _turretToBuild.cost;
        _putTurret.Play();
        GameObject turret = (GameObject)Instantiate(_turretToBuild.prefab, node.transform.position + node.positionOffset, node.transform.rotation, _root);
        node.turret = turret;
    }

    public void SelectTurretToBuild(TurretBlueprints turret)
    {
        _turretToBuild = turret;
    }
}

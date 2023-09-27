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

    public GameObject standarTurretPrefab;

    private GameObject turretToBuild;
    void Start()
    {
        turretToBuild = standarTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }


    void Update()
    {
        
    }
}

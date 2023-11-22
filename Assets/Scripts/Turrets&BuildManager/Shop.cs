using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shop : Singleton<Shop>
{
    [SerializeField] private Button _powerUpButton;

    public TurretBlueprints turret1;
    public TurretBlueprints turret2;
    public ObstacleStats obstaclesStats;
    public PowerUpStats powerUpStats;
    public ArrowStats _arrowStats;

    public int _currDamage;

    private void Start()
    {
        _powerUpButton.onClick.AddListener(PowerUpEnable);
        _currDamage = _arrowStats.Damage;
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

    //POWERUP-------- zone
    private void PowerUpEnable()
    {
        if (GameManager.Instance.VolatileData.Coins < powerUpStats.PowerUpCost) return;

        StartCoroutine(PlayPowerUp());
        GameManager.Instance.VolatileData.Coins -= powerUpStats.PowerUpCost;
    }

    private IEnumerator PlayPowerUp()
    {
        _powerUpButton.interactable = false;
        DamageModified(powerUpStats.MultiplyDamage);

        yield return new WaitForSeconds(powerUpStats.PowerUpDuration);

        OriginalDamage();
        _powerUpButton.interactable = true;
    }

    private int DamageModified(int multiplied)
    {
        _currDamage = multiplied * _arrowStats.Damage;
        return _currDamage;
    }

    private void OriginalDamage()
    {
        _currDamage = _arrowStats.Damage;
    }
}

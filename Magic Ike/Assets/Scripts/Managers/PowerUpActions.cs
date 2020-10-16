using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActions : MonoBehaviour
{
    #region Singleton

    public static PowerUpActions instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    [Header("Spell Prefabs")]
    [SerializeField]
    private GameObject firePrefab = null;
    [SerializeField]
    private GameObject icePrefab = null;
    [SerializeField]
    private GameObject lightPrefab = null;
    [SerializeField]
    private GameObject defaultPrefab = null;

    private PlayerStats playerStats;
    private PlayerController playerController;
    private PowerUpManager manager;

    private void Start()
    {
        playerController = PlayerManager.instance.player.GetComponent<PlayerController>();
        playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        manager = PowerUpManager.instance;
    }

    public void HealthUpStart()
    {
        playerStats.TakeDamage(-50);
    }

    public void ManaUpStart()
    {
        playerStats.ReduceMana(-50);
    }

    public void SpeedUpStart()
    {
        playerController.speed *= 2;
        playerController.turnSpeed *= 2;
    }

    public void SpeedUpEnd()
    {
        playerController.speed /= 2;
        playerController.turnSpeed /= 2;
    }

    public void AttackUpStart()
    {
        playerStats.attackSpeed *= 3;
        playerStats.manaRegen *= 6;
    }

    public void AttackUpEnd()
    {
        playerStats.attackSpeed /= 3;
        playerStats.manaRegen /= 6;
    }

    public void FireUpStart()
    {
        playerController.projectilePrefab = firePrefab;
        //if( ice or light are active)
        //{
        //    manager.activePowerUps.Remove( the active power up );
        //    manager.keys = new List<PowerUp>(manager.activePowerUps.Keys);
        //}
    }

    public void FireUpEnd()
    {
        playerController.projectilePrefab = defaultPrefab;
    }

    public void IceUpStart()
    {
        playerController.projectilePrefab = icePrefab;
    }

    public void IceUpEnd()
    {
        playerController.projectilePrefab = defaultPrefab;
    }

    public void LightUpStart()
    {
        playerController.projectilePrefab = lightPrefab;
    }

    public void LightUpEnd()
    {
        playerController.projectilePrefab = defaultPrefab;
    }
}

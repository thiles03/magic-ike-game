using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    #region Singleton

    public static PowerUpManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject[] powerUpPrefabs;

    public List<PowerUp> powerUps;

    public Dictionary<PowerUp, float> activePowerUps = new Dictionary<PowerUp, float>();

    public List<PowerUp> keys { get; set; } = new List<PowerUp>();

    private void Update()
    {
        HandleActivePowerups();
    }

    public void HandleActivePowerups()
    {
        bool changed = false;

        if (activePowerUps.Count > 0)
        {
            foreach (PowerUp powerUp in keys)
            {
                if (activePowerUps[powerUp] > 0)
                {
                    activePowerUps[powerUp] -= Time.deltaTime;
                }
                else
                {
                    changed = true;
                    activePowerUps.Remove(powerUp);
                    powerUp.End();
                }
            }
        }

        if(changed)
        {
            keys = new List<PowerUp>(activePowerUps.Keys);
        }
    }

    public void ActivatePowerUp(PowerUp powerUp)
    {
        if (!activePowerUps.ContainsKey(powerUp))
        {
            powerUp.Start();
            activePowerUps.Add(powerUp, powerUp.duration);
        }
        else
        {
            activePowerUps[powerUp] += powerUp.duration; 
        }

        keys = new List<PowerUp>(activePowerUps.Keys);
    }

    public GameObject SpawnPowerUp(int i, Vector3 position)
    {
        GameObject powerUpGameObject = Instantiate(powerUpPrefabs[i]);

        var powerUpBehaviour = powerUpGameObject.GetComponent<PowerUpBehaviour>();
        powerUpBehaviour.manager = this;
        powerUpBehaviour.SetPowerUp(powerUps[i]);

        powerUpGameObject.transform.position = position;

        return powerUpGameObject;
    }
}

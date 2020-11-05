using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    public GameObject projectilePrefab;

    private PowerUpManager powerUpManager;
    private SpawnManager manager;
    private int enemyIndex = 0;


    void Start()
    {
        powerUpManager = PowerUpManager.instance;
        
        manager = SpawnManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            powerUpManager.SpawnPowerUp(0, new Vector3(-30, 0, -200));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            powerUpManager.SpawnPowerUp(1, new Vector3(-30, 0, -190));
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            powerUpManager.SpawnPowerUp(2, new Vector3(-30, 0, -180));
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            powerUpManager.SpawnPowerUp(3, new Vector3(-30, 0, -170));
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            powerUpManager.SpawnPowerUp(4, new Vector3(-30, 0, -160));
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            powerUpManager.SpawnPowerUp(5, new Vector3(-30, 0, -150));
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            powerUpManager.SpawnPowerUp(6, new Vector3(-30, 0, -140));
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnEnemy();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Score.score += 100;
        }
    }


    void SpawnEnemy()
    {
        int i = 2;
        bool complete = false;

        foreach (int score in manager.level)
        {
            if (Score.score < score)
            {
                enemyIndex = Random.Range(0, i);
                complete = true;
                break;
            }

            i++;
        }

        if (complete == false)
        {
            enemyIndex = Random.Range(0, 9);
        }

            //If enemy limit hasn't been reached, spawn an enemy
            if (manager.enemyCount < manager.enemyLimit)
        {
            Instantiate(manager.enemyPrefabs[enemyIndex], transform.position, transform.rotation);
            manager.enemyCount++;
        }
    }
}

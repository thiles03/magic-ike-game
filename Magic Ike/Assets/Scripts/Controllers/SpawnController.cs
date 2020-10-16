using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private float deactivateRadius = 70f;

    private SpawnManager manager;
    private Vector3 playerPosition;
    private bool isDead;
    private int enemyIndex = 0;
    private bool isActive = true;
    private bool isRunning = false;

    void Start()
    {
        manager = SpawnManager.instance;

        playerPosition = PlayerManager.instance.player.transform.position;

        Instantiate(manager.enemyPrefabs[enemyIndex], transform.position, transform.rotation);

        manager.enemyCount++;
    }

    private void Update()
    {
        isActive = Vector3.Distance(playerPosition, transform.position) > deactivateRadius;
        isDead = PlayerManager.instance.player.GetComponent<PlayerStats>().isDead;

        if (!isRunning && isActive)
        {
            isRunning = true;
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (isActive && !isDead)
        {
            yield return new WaitForSecondsRealtime(manager.spawnInterval);

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

        isRunning = false;
    }
}

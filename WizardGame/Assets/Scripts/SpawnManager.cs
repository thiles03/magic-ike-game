using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static int enemyCount = 0;
    
    private static int enemyLimit = 30;
    private static int levelOne = 20;
    private static int levelTwo = 50;
    private static int levelThree = 100;
    private static int levelFour = 400;
    private static int levelFive = 800;
    private static int levelSix = 1500;
    private static int levelSeven = 2500;

    [Header("Spawn Parameters")]
    [SerializeField]
    private GameObject[] enemyPrefabs = null;
    [SerializeField]
    private float spawnDelay = 1;
    [SerializeField]
    private float spawnInterval = 10;

    private int enemyIndex = 0;
    private Vector3 spawnPos = new Vector3();


    void Start()
    {
        spawnPos = transform.position;

        InvokeRepeating("SpawnEnemy", spawnDelay, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (Score.score < levelOne)
        {
            enemyIndex = Random.Range(0, 2);
        }
        else if(Score.score >= levelOne && Score.score < levelTwo)
        {
            enemyIndex = Random.Range(0, 3);
        }
        else if (Score.score >= levelTwo && Score.score < levelThree)
        {
            enemyIndex = Random.Range(0, 4);
        }
        else if (Score.score >= levelThree && Score.score < levelFour)
        {
            enemyIndex = Random.Range(0, 5);
        }
        else if (Score.score >= levelFour && Score.score < levelFive)
        {
            enemyIndex = Random.Range(0, 6);
        }
        else if (Score.score >= levelFive && Score.score < levelSix)
        {
            enemyIndex = Random.Range(0, 7);
        }
        else if (Score.score >= levelSix && Score.score < levelSeven)
        {
            enemyIndex = Random.Range(0, 8);
        }
        else if (Score.score >= levelSeven)
        {
            enemyIndex = Random.Range(0, 9);
        }

        if (enemyCount < enemyLimit)
        {
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, transform.rotation);
            enemyCount++;
        }
    }
}

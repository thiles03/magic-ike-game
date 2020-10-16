using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Singleton

    public static SpawnManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public int enemyCount {get; set;} = 0;

    //Score boundaries for spawning different enemies
    [Header("Score Boundaries")]
    public int[] level = new int[7];
    
    [Header("Spawn Parameters")]
    public int enemyLimit = 30; //Maximum enemies present in level
    public GameObject[] enemyPrefabs = null;
    public float spawnDelay = 1;
    public float spawnInterval = 15;
}

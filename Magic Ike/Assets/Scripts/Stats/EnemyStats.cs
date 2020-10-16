using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public int maxAttackDamage  = 1;
    public int minAttackDamage = 1;
    public float dropRate = 2f;

    [SerializeField]
    private int score = 1;

    protected override void Die()
    {
        base.Die();

        Score.score += score;

        SpawnManager.instance.enemyCount--;
        
        Destroy(gameObject, 2f);

        //Random chance to drop powerup
        float dropValue = Random.Range(0f, 100f);

        if (dropValue < dropRate)
        {
            int index = Random.Range(0, 7);
            PowerUpManager.instance.SpawnPowerUp(index, transform.position);
        }
    }
}

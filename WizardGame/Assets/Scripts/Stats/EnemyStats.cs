using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public int maxAttackDamage  = 1;
    public int minAttackDamage = 1;

    [SerializeField]
    private int score = 1;

    protected override void Die()
    {
        base.Die();

        Score.score += score;
        Destroy(gameObject, 3f);
        SpawnManager.enemyCount--;
    }
}

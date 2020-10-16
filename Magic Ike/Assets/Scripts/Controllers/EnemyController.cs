using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Temporary. Sync animation.
    public float attackDelay;

    //Reference player position and stats
    private Transform target;
    private PlayerStats targetStats;

    //Own stats
    private EnemyStats myStats;

    //Reference to own NavMeshAgent and AnimationController
    private NavMeshAgent navAgent;
    private AnimationController animController;

    void Start()
    {
        //Build references
        target = PlayerManager.instance.player.transform;
        targetStats = target.GetComponent<PlayerStats>();
        myStats = GetComponent<EnemyStats>();
        navAgent = GetComponent<NavMeshAgent>();
        animController = GetComponent<AnimationController>();

        //Start movement
        StartCoroutine(ActivateEnemy());
    }

    void Update()
    {
        //If enemy or player dies, stop movement
        if (myStats.isDead || targetStats.isDead)
        {
            DeactivateEnemy();
        }
    }

    IEnumerator ActivateEnemy()
    {
        //If enemy and player are alive, move to player and attack
        while (!myStats.isDead && !targetStats.isDead)
        {
            yield return null; 

            float distance = Vector3.Distance(target.position, transform.position);
            navAgent.SetDestination(target.position);
            animController.MoveAnimationStart();

            if (distance <= navAgent.stoppingDistance)
            {
                animController.MoveAnimationStop();
                FaceTarget();
                Attack(Random.Range(myStats.minAttackDamage, myStats.maxAttackDamage));
            }
        }
    }

    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void Attack(int damage)
    {
        if (myStats.attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(damage, attackDelay));
            animController.AttackAnimation();
            myStats.ResetCooldown();
        }
    }

    void DeactivateEnemy()
    {
        animController.MoveAnimationStop();
        navAgent.ResetPath();
        navAgent.velocity = Vector3.zero;
        GetComponent<Collider>().enabled = false;
    }

    //Temp, sync animation
    IEnumerator DoDamage (int damage, float delay)
    {
        yield return new WaitForSeconds(delay);

        targetStats.TakeDamage(damage);
    }
}

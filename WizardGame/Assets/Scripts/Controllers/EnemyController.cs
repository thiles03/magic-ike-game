using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float attackDelay;

    private Transform target;
    private NavMeshAgent navAgent;
    private EnemyStats myStats;
    private AnimationController animController;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        navAgent = GetComponent<NavMeshAgent>();
        myStats = GetComponent<EnemyStats>();
        animController = GetComponent<AnimationController>();
    }

    void Update()
    {
        if(myStats.isDead == false && target.GetComponent<PlayerStats>().isDead == false)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            navAgent.SetDestination(target.position);
            animController.MoveAnimationStart();

            if (distance <= navAgent.stoppingDistance)
            {
                animController.MoveAnimationStop();
                Attack(Random.Range(myStats.minAttackDamage, myStats.maxAttackDamage));
                FaceTarget();
            }
        }

        if (myStats.isDead || target.GetComponent<PlayerStats>().isDead == true)
        {
            animController.MoveAnimationStop();
            navAgent.ResetPath();
            navAgent.velocity = Vector3.zero;
            GetComponent<Collider>().enabled = false;
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

    IEnumerator DoDamage (int damage, float delay)
    {
        yield return new WaitForSeconds(delay);

        target.GetComponent<PlayerStats>().TakeDamage(damage);
    }
}

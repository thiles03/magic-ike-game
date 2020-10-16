using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Stats")]
    public float attackSpeed = 1f;
    [SerializeField]
    private int maxHealth = 100;
    
    public int currentHealth { get; private set; }
    public float attackCooldown { get; private set; } = 0;
    public bool isDead { get; protected set; }  = false;

    [SerializeField]
    private StatBarController healthBar = null;
    private AnimationController animController;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetSliderMax(maxHealth);
        animController = GetComponent<AnimationController>();
    }

    protected virtual void Update()
    {
        if(attackCooldown > 0f)
        {
            attackCooldown -= Time.deltaTime * attackSpeed;
        }
    }

    public void ResetCooldown()
    {
        attackCooldown = 1f;
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;

        if (damage > 0)
        {

            animController.HitAnimation();
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            Die();
        }

        healthBar.SliderValue(currentHealth);
    }

    protected virtual void Die()
    {
        animController.DieAnimation();
        isDead = true;
    }
}

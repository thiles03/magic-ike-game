using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private float attackSpeed = 1f;

    public int currentHealth { get; private set; }
    public float attackCooldown { get; private set; } = 0;
    public bool isDead { get; protected set; }  = false;

    public StatBarController healthBar;

    private AnimationController animController;
    private SoundController soundController;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetSliderMax(maxHealth);
        animController = GetComponent<AnimationController>();
        soundController = GetComponent<SoundController>();
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
        healthBar.SliderValue(currentHealth);
        animController.HitAnimation();
        //soundController.GetHit();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        animController.DieAnimation();
        isDead = true;
    }
}

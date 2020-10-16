using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public float manaRegen = 10;

    [SerializeField]
    private int maxMana = 100;
    [SerializeField]
    private StatBarController manaBar = null;

    public float currentMana { get; private set; }

    private void Awake()
    {
        currentMana = maxMana;
        manaBar.SetSliderMax(maxMana);
    }

    protected override void Update()
    {
        base.Update();

        if (currentMana < maxMana)
        {
            ManaRegen();
        }
    }

    private void ManaRegen()
    {
        currentMana += manaRegen * Time.deltaTime;

        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }

        manaBar.SliderValue(currentMana);
    }

    public void ReduceMana(int amount)
    {
        currentMana -= amount;
        manaBar.SliderValue(currentMana);

        if (currentMana < 0)
        {
            currentMana = 0;
        }
    }

    protected override void Die()
    {
        base.Die();
        PlayerManager.instance.GameOver();
    }

}

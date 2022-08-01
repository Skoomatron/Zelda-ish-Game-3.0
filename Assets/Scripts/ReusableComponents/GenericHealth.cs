using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    public FloatValue maxHealth;
    [SerializeField] private float currentHealth;
    void Start()
    {
        currentHealth = maxHealth.RuntimeValue;
    }
    public void Heal(float amountHealed)
    {
        currentHealth += amountHealed;
        if (currentHealth > maxHealth.RuntimeValue)
        {
            currentHealth = maxHealth.RuntimeValue;
        }
    }
    public void FullHeal()
    {
        currentHealth = maxHealth.RuntimeValue;
    }
    public void InstantDeath()
    {
        currentHealth = 0;
    }
    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    public FloatValue maxHealth;
    [SerializeField] private float currentHealth;
    void Start()
    {
        currentHealth = maxHealth.runtimeValue;
    }
    public virtual void Heal(float amountHealed)
    {
        currentHealth += amountHealed;
        if (currentHealth > maxHealth.runtimeValue)
        {
            currentHealth = maxHealth.runtimeValue;
        }
    }
    public virtual void FullHeal()
    {
        currentHealth = maxHealth.runtimeValue;
    }
    public virtual void InstantDeath()
    {
        currentHealth = 0;
    }
    public virtual void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }
}

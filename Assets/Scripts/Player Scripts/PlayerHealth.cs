using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : GenericHealth
{
    [SerializeField] private SignalClass healthSignal;
    public override void Damage(float damageAmount)
    {
        base.Damage(damageAmount);
        maxHealth.runtimeValue = currentHealth;
        healthSignal.Raise();
    }
}

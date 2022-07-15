using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealth : PowerUp
{
    public FloatValue playerHealth;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth.initialValue += 1;
            playerHealth.runtimeValue = playerHealth.initialValue;
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp
{
    public FloatValue playerHealth;
    public float healthGained;
    public FloatValue heartContainers;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerHealth.runtimeValue += healthGained;
            if (playerHealth.runtimeValue > heartContainers.runtimeValue * 2f)
            {
                playerHealth.runtimeValue = heartContainers.runtimeValue * 2f;
            }
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}

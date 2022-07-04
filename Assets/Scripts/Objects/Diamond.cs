using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : PowerUp
{
    public Inventory playerInventory;
    void Start()
    {

    }

    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerInventory.diamonds += 1;
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}

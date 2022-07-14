using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBottle : PowerUp
{
    public Inventory playerInventory;
    public float magicValue;
    void Start()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerInventory.currentMagic += magicValue;
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}

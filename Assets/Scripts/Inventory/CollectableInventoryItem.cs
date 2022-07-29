using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem thisItem;

    void AddItemToInventory()
    {
        if (playerInventory && thisItem)
        {
            if (playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.numberHeld++;
            }
            else
            {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld++;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")  && !collision.isTrigger)
        {
            AddItemToInventory();
            Destroy(this.gameObject);
        }
    }
}

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
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AddItemToInventory();
            Destroy(this.gameObject);
        }
    }
}

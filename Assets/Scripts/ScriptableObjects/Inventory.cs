using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
[System.Serializable]

public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfKeyItems;
    public int diamonds;
    public float currentMagic;
    public float maxMagic = 10;
    public void OnEnable()
    {
        currentMagic = maxMagic;
    }
    public void ReduceMagic(float magicCost)
    {
        currentMagic -= magicCost;
    }
    public bool ItemCheck(Item item)
    {
        if (items.Contains(item))
        {
            return true;
        }
        return false;
    }
    public void AddItem(Item itemToAdd)
    {
        if (itemToAdd.keyItem)
        {
            numberOfKeyItems++;
        } else {
            if (!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }
        }
    }
}
